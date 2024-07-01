using ExpenseManager.Domain.Common.Models;
using ExpenseManager.Domain.Common.Models.Identities;

namespace ExpenseManager.Domain.UserAggregate.ValueObjects;
public class UserId : AggregateRootId<Guid>
{
    private UserId(Guid value) : base(value)
    {
    }

    public static UserId CreateUnique()
    {
        UserId userId = new(Guid.NewGuid());
        return userId;
    }

    public static UserId Create(string userId)
    {
        return new UserId(Guid.Parse(userId));
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