using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Guests.ValueObjects;

public sealed class RatingId : ValueObject
{
    public Guid Value { get; }

    private RatingId() { }

    private RatingId(Guid value)
    {
        Value = value;
    }

    public static RatingId CreateUnique()
    {
        return new RatingId(Guid.NewGuid());
    }

    public static RatingId Create(Guid value)
    {
        return new RatingId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}