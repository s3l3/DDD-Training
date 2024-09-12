using BuberDinner.Domain.Users;
using BuberDinner.Domain.Users.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ConfigureUsersTable(builder);
    }

    private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => UserId.Create(value));
    }
}