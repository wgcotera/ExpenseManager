using ErrorOr;

using ExpenseManager.Domain.Common.DomainErrors;
using ExpenseManager.Domain.Common.Models;

namespace ExpenseManager.Domain.UserAggregate.ValueObjects;
public class UserId : ValueObject
{
    public Guid Value { get; }

    private UserId(Guid value)
    {
        Value = value;
    }

    public static UserId CreateUnique()
    {
        UserId userId = new(Guid.NewGuid());
        return userId;
    }

    public static UserId Create(string value)
    {
        return new UserId(Guid.Parse(value));
    }

    public static UserId Create(Guid userId)
    {
        return new UserId(userId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}