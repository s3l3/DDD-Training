using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus.ValueObjects;

namespace BuberDinner.Domain.Dinners;

public sealed class Dinner : AggregateRoot<DinnerId, Guid>
{
    private readonly List<Reservation> _reservations = new();

    public string Name { get; private set; }

    public string Description { get; private set; }

    public DateTime StartDateTime { get; private set; }

    public DateTime EndDateTime { get; private set; }

    public DateTime? StartedDateTime { get; private set; }

    public DateTime? EndedDateTime { get; private set; }

    public string Status { get; private set; }

    public bool IsPublic { get; private set; }

    public int MaxGuests { get; private set; }

    public Price Price { get; private set; }

    public HostId HostId { get; private set; }

    public MenuId MenuId { get; private set; }

    public string ImageUrl { get; private set; }

    public Location Location { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

    public IReadOnlyList<Reservation> Reservations => _reservations.ToList();

#pragma warning disable CS8618
    private Dinner() { }
#pragma warning restore CS8618

    private Dinner(
        DinnerId id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        string status,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        string imageUrl,
        Location location,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(id)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Status = status;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        ImageUrl = imageUrl;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Dinner Create(
    string name,
    string description,
    DateTime startDateTime,
    DateTime endDateTime,
    string status,
    bool isPublic,
    int maxGuests,
    Price price,
    HostId hostId,
    MenuId menuId,
    string imageUrl,
    Location location)
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            status,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            imageUrl,
            location,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}
