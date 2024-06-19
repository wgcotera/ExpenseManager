using ExpenseManager.Domain.Common.Models;

namespace ExpenseManager.Domain.UserAggregate.ValueObjects;
public class UserId : ValueObject
{
    public Guid Value { get; }

    private UserId(Guid value) => Value = value;

    // static factory method
    public static UserId CreateUnique()
    {
        UserId userId = new(Guid.NewGuid());
        return userId;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}