using System.Reflection.PortableExecutable;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entites;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    public string Name { get; }
    public string Description { get; }
    public float AverageRating { get; }
    private readonly List<MenuSection> _menuSections = new();
    public IReadOnlyList<MenuSection> MenuSections => _menuSections.ToList();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public HostId HostId { get; }
    private readonly List<DinnerId> _dinnerIds = new();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.ToList();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.ToList();


    private Menu(
        MenuId id,
        string name,
        string description,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(
        string name,
        string description,
        HostId hostId)
    {
        return new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            hostId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}