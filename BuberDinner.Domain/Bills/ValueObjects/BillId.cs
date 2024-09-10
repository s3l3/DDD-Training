using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Bills.ValueObjects;

public class BillId : AggregateRootId<Guid>
{
    public override Guid Value { get; protected set; }

    private BillId() { }

    private BillId(Guid value)
    {
        Value = value;
    }

    public static BillId CreateUnique()
    {
        return new BillId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}