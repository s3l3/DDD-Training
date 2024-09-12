using BuberDinner.Domain.Bills.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests.Entities;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.MenuReviews.ValueObjects;
using BuberDinner.Domain.Users.ValueObjects;

namespace BuberDinner.Domain.Guests;

public sealed class Guest : AggregateRoot<GuestId, Guid>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new();
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();
    private readonly List<RatingEntity> _ratings = new();

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string ProfileImage { get; private set; }

    public AverageRating AverageRating { get; private set; }

    public UserId UserId { get; set; }

    public DateTime CreatedDateTime { get; }

    public DateTime UpdatedDateTime { get; }

    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.ToList();

    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.ToList();

    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.ToList();

    public IReadOnlyList<BillId> BillIds => _billIds.ToList();

    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.ToList();

    public IReadOnlyList<RatingEntity> Ratings => _ratings.ToList();

#pragma warning disable CS8618
    private Guest() { }
#pragma warning restore CS8618

    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(guestId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId)
    {
        return new(
            GuestId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}