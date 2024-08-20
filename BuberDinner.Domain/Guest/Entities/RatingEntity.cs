using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Guest.Entities;

public sealed class RatingEntity : Entity<RatingId>
{
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public int RatingValue { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private RatingEntity(
        RatingId ratingId,
        HostId hostId,
        DinnerId dinnerId,
        int ratingValue,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(ratingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        RatingValue = ratingValue;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static RatingEntity Create(HostId hostId, DinnerId dinnerId, int ratingValue)
    {
        return new(RatingId.CreateUnique(), hostId, dinnerId, ratingValue, DateTime.UtcNow, DateTime.UtcNow);
    }
}
