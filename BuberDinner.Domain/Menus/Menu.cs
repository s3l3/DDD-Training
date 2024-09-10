using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus.Entites;
using BuberDinner.Domain.Menus.ValueObjects;
using BuberDinner.Domain.MenuReviews.ValueObjects;

namespace BuberDinner.Domain.Menus;

public sealed class Menu : AggregateRoot<MenuId, Guid>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; private set; }

    public string Description { get; private set; }

    public AverageRating AverageRating { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    public HostId HostId { get; private set; }

    public IReadOnlyList<MenuSection> Sections => _sections.ToList();

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.ToList();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.ToList();

#pragma warning disable CS8618
    private Menu() { }
#pragma warning restore CS8618

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
        _sections = menuSections;
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