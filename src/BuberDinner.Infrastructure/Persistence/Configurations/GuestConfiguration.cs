using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Users.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        ConfigureGuestsTable(builder);
        ConfigurePastDinnerIdsTable(builder);
        ConfigureUpcomingDinnerIdsTable(builder);
        ConfigurePendingDinnerIdsTable(builder);
        ConfigureBillIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);
        ConfigureRatingsTable(builder);
    }

    private void ConfigureGuestsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable("Guests");

        builder.HasKey("Id");

        builder.Property(g => g.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => GuestId.Create(value));

        builder.Property(g => g.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));

        builder.Property(g => g.FirstName)
           .HasMaxLength(20);

        builder.Property(g => g.LastName)
           .HasMaxLength(20);

        builder.OwnsOne(g => g.AverageRating);
    }

    private void ConfigurePastDinnerIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.PastDinnerIds, dinnerIdsBuilder =>
        {
            dinnerIdsBuilder.ToTable("GuestPastDinnerIds");

            dinnerIdsBuilder
                .WithOwner()
                .HasForeignKey("GuestId");

            dinnerIdsBuilder.HasKey("Id");

            dinnerIdsBuilder
                .Property(d => d.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Guest.PastDinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureUpcomingDinnerIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.UpcomingDinnerIds, dinnerIdsBuilder =>
        {
            dinnerIdsBuilder.ToTable("GuestUpcomingDinnerIds");

            dinnerIdsBuilder
                .WithOwner()
                .HasForeignKey("GuestId");

            dinnerIdsBuilder.HasKey("Id");

            dinnerIdsBuilder
                .Property(id => id.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Guest.UpcomingDinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigurePendingDinnerIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.PendingDinnerIds, dinnerIdsBuilder =>
        {
            dinnerIdsBuilder.ToTable("GuestPendingDinnerIds");

            dinnerIdsBuilder
                .WithOwner()
                .HasForeignKey("GuestId");

            dinnerIdsBuilder.HasKey("Id");

            dinnerIdsBuilder
                .Property(id => id.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Guest.PendingDinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureBillIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.BillIds, billIdsBuilder =>
        {
            billIdsBuilder.ToTable("GuestBillIds");

            billIdsBuilder
                .WithOwner()
                .HasForeignKey("GuestId");

            billIdsBuilder.HasKey("Id");

            billIdsBuilder
                .Property(id => id.Value)
                .HasColumnName("BillId")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Guest.BillIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.MenuReviewIds, menuReviewIdsBuilder =>
        {
            menuReviewIdsBuilder.ToTable("GuestMenuReviewIds");

            menuReviewIdsBuilder
                .WithOwner()
                .HasForeignKey("GuestId");

            menuReviewIdsBuilder.HasKey("Id");

            menuReviewIdsBuilder
                .Property(id => id.Value)
                .HasColumnName("MenuReviewId")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Guest.MenuReviewIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureRatingsTable(EntityTypeBuilder<Guest> builder)
    {
        builder.OwnsMany(g => g.Ratings, ratingBuilder =>
        {
            ratingBuilder.ToTable("GuestRatings");

            ratingBuilder
                .WithOwner()
                .HasForeignKey("GuestId");

            ratingBuilder.HasKey("Id", "GuestId");

            ratingBuilder
                .Property(r => r.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => RatingId.Create(value));

            ratingBuilder
                .Property(r => r.HostId)
                .HasConversion(
                    id => id.Value,
                    value => HostId.Create(value));

            ratingBuilder
                .Property(r => r.DinnerId)
                .HasConversion(
                    id => id.Value,
                    value => DinnerId.Create(value));
        });
    }
}