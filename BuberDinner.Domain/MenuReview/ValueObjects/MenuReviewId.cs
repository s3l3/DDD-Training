using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.MenuReview.ValueObjects;

public class MenuReviewId : ValueObject
{
    public Guid Value { get; }

    public MenuReviewId(Guid value)
    {
        Value = value;
    }

    public static MenuReviewId CreateUnique()
    {
        return new MenuReviewId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}