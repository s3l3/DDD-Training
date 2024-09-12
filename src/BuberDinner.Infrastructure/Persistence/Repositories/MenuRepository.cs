using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menus;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{

    private readonly BubberDinnerDbContext _dbContext;

    public MenuRepository(BubberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Menu menu)
    {
        await _dbContext.AddAsync(menu);
        await _dbContext.SaveChangesAsync();
    }
}