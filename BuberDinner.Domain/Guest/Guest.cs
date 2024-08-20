using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest;

public class Guest : AggregateRoot<GuestId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; set; }
    private List<DinnerId> _upcomingDinnerIds = new();
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => _upcomingDinnerIds.ToList();
    private List<DinnerId> _pastDinnerIds = new();
    public IReadOnlyList<DinnerId> PastDinnerIds => _pastDinnerIds.ToList();
    private List<DinnerId> _pendingDinnerIds = new();
    public IReadOnlyList<DinnerId> PendingDinnerIds => _pendingDinnerIds.ToList();
    private List<BillId> _billIds = new();
    public IReadOnlyList<BillId> BillIds => _billIds.ToList();
    private List<MenuReviewId> _menuReviewIds = new();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.ToList();
    private List<RatingEntity> _ratings = new();
    public IReadOnlyList<RatingEntity> Ratings => _ratings.ToList();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

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
