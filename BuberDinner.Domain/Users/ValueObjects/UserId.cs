using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Users.ValueObjects;

public sealed class UserId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private UserId() { }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}