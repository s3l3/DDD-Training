using BuberDinner.Domain.Dinners;
using BuberDinner.Domain.Hosts;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Users.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class HostConfiguration : IEntityTypeConfiguration<Host>
{
    public void Configure(EntityTypeBuilder<Host> builder)
    {
        ConfigureHostsTable(builder);
        ConfigureMenuIdsTable(builder);
        ConfigureDinnerIdsTable(builder);
    }

    private void ConfigureHostsTable(EntityTypeBuilder<Host> builder)
    {
        builder.ToTable("Hosts");

        builder.HasKey("Id");

        builder.Property(h => h.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => HostId.Create(value));

        builder.Property(h => h.FirstName)
            .HasMaxLength(30);

        builder.Property(h => h.LastName)
            .HasMaxLength(30);

        builder.OwnsOne(h => h.AverageRating);

        builder.Property(h => h.UserId)
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
    }

    private void ConfigureMenuIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(h => h.MenuIds, menuIdsBuilder =>
        {
            menuIdsBuilder.ToTable("HostMenuIds");

            menuIdsBuilder
                .WithOwner()
                .HasForeignKey("HostId");

            menuIdsBuilder.HasKey("Id");

            menuIdsBuilder
                .Property(id => id.Value)
                .HasColumnName("MenuId")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Host.MenuIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private void ConfigureDinnerIdsTable(EntityTypeBuilder<Host> builder)
    {
        builder.OwnsMany(h => h.DinnerIds, dinnerIdsBuilder =>
        {
            dinnerIdsBuilder.ToTable("HostDinnerIds");

            dinnerIdsBuilder
                .WithOwner()
                .HasForeignKey("HostId");

            dinnerIdsBuilder.HasKey("Id");

            dinnerIdsBuilder
                .Property(id => id.Value)
                .HasColumnName("DinnerId")
                .ValueGeneratedNever();
        });

        builder.Metadata
            .FindNavigation(nameof(Host.DinnerIds))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}