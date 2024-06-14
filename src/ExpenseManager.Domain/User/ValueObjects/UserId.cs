using BuberDinner.Domain.Common.Models;

namespace ExpenseManager.Domain.User.ValueObjects;
public class UserId : ValueObject
{
    public Guid Value { get; }

    private UserId(Guid value) => Value = value;

    // static factory method
    public static UserId CreateUnique() => new UserId(new Guid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}