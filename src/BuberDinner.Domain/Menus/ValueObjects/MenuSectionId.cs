using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menus.ValueObjects;

public sealed class MenuSectionId : ValueObject
{
    public Guid Value { get; }

    private MenuSectionId() { }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid value)
    {
        return new MenuSectionId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        {
            yield return Value;
        }
    }
}