using BuberDinner.Domain.Menus;
using BuberDinner.Domain.Users;

using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence;

public sealed class BubberDinnerDbContext : DbContext
{
    public BubberDinnerDbContext(DbContextOptions<BubberDinnerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Menu> Menus { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(BubberDinnerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}