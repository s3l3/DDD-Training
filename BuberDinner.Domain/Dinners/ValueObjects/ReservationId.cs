using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinners.ValueObjects;

public class ReservationId : ValueObject
{
    public Guid Value { get; }

    private ReservationId() { }

    private ReservationId(Guid value)
    {
        Value = value;
    }

    public static ReservationId CreateUnique()
    {
        return new ReservationId(Guid.NewGuid());
    }

    public static ReservationId Create(Guid value)
    {
        return new ReservationId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}