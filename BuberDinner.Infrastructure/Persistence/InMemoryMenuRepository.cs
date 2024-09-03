using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menus;

namespace BuberDinner.Infrastructure.Persistence;

public class InMemoryMenuRepository : IMenuRepository
{

    private static readonly List<Menu> _menus = new();

    public void Add(Menu menu)
    {
        _menus.Add(menu);
    }

}