using BuberDinner.Domain.Bills.ValueObjects;
using BuberDinner.Domain.Dinners;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class DinnerConfiguration : IEntityTypeConfiguration<Dinner>
{
    public void Configure(EntityTypeBuilder<Dinner> builder)
    {
        ConfigureDinnersTable(builder);
        ConfigureReservationsTable(builder);
    }

    private void ConfigureDinnersTable(EntityTypeBuilder<Dinner> builder)
    {
        builder.ToTable("Dinners");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => DinnerId.Create(value));

        builder.Property(d => d.Name)
            .HasMaxLength(100);

        builder.Property(d => d.Description)
            .HasMaxLength(100);

        builder.Property(d => d.Status)
            .HasMaxLength(25);

        builder
            .Property(d => d.StartedDateTime)
            .IsRequired(false);

        builder
            .Property(d => d.EndedDateTime)
            .IsRequired(false);

        builder.OwnsOne(d => d.Price);

        builder.OwnsOne(d => d.Location);

        builder.Property(d => d.HostId)
               .HasConversion(
                    id => id.Value,
                    value => HostId.Create(value));

        builder.Property(d => d.MenuId)
               .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value));
    }

    private void ConfigureReservationsTable(EntityTypeBuilder<Dinner> builder)
    {
        builder
            .OwnsMany(d => d.Reservations, reservationsBuilder =>
            {
                reservationsBuilder.ToTable("Reservations");

                reservationsBuilder
                    .WithOwner()
                    .HasForeignKey("DinnerId");

                reservationsBuilder
                    .Property(reservationsBuilder => reservationsBuilder.Id)
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => ReservationId.Create(value));

                reservationsBuilder
                    .Property(reservationsBuilder => reservationsBuilder.GuestId)
                    .HasConversion(
                        id => id.Value,
                        value => GuestId.Create(value));

                reservationsBuilder
                    .Property(reservationsBuilder => reservationsBuilder.BillId)
                    .HasConversion(
                        id => id.Value,
                        value => BillId.Create(value));

                reservationsBuilder
                    .Property(reservationsBuilder => reservationsBuilder.ArrivalDateTime)
                    .IsRequired(false);
            });
    }
}