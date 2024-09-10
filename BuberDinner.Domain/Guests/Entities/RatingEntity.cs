using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinners.ValueObjects;
using BuberDinner.Domain.Guests.ValueObjects;
using BuberDinner.Domain.Hosts.ValueObjects;

namespace BuberDinner.Domain.Guests.Entities;

public sealed class RatingEntity : Entity<RatingId>
{
    public HostId HostId { get; private set; }

    public DinnerId DinnerId { get; private set; }

    public int RatingValue { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

#pragma warning disable CS8618
    private RatingEntity() { }
#pragma warning restore CS8618

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
