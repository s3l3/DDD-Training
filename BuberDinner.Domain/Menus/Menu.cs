using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus.Entites;
using BuberDinner.Domain.Menus.ValueObjects;
using BuberDinner.Domain.MenuReviews.ValueObjects;

namespace BuberDinner.Domain.Menus;

public sealed class Menu : AggregateRoot<MenuId>
{
    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get; }
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
        AverageRating averageRating,
        HostId hostId,
        List<MenuSection> menuSections,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(id)
    {
        Name = name;
        Description = description;
        AverageRating = averageRating;
        HostId = hostId;
        _menuSections = menuSections;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Menu Create(
        string name,
        string description,
        HostId hostId,
        List<MenuSection>? menuSections)
    {
        return new Menu(
            MenuId.CreateUnique(),
            name,
            description,
            AverageRating.CreateNew(0),
            hostId,
            menuSections ?? new(),
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}