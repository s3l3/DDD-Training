using BuberDinner.Domain.Menus;

using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence;

public sealed class BubberDinnerDbContext : DbContext
{
    public BubberDinnerDbContext(DbContextOptions<BubberDinnerDbContext> options)
        : base(options)
    {
    }

    public DbSet<Menu> Menus { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(BubberDinnerDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}