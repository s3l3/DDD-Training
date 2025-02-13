using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;
using BuberDinner.Domain.Menus.ValueObjects;
using BuberDinner.Domain.Users.ValueObjects;

namespace BuberDinner.Domain.Hosts;

public sealed class Host : AggregateRoot<HostId, Guid>
{
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string ProfileImage { get; private set; }

    public AverageRating AverageRating { get; private set; }

    public UserId UserId { get; }

    public IReadOnlyList<MenuId> MenuIds => _menuIds.ToList();

    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.ToList();

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

#pragma warning disable CS8618
    private Host() { }
#pragma warning restore CS8618

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId)
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}