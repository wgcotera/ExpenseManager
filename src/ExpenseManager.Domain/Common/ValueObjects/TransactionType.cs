using BuberDinner.Domain.Common.Models;

namespace ExpenseManager.Domain.Common.ValueObjects;

public class TransactionType : ValueObject
{
    public Guid Value { get; }

    private TransactionType(Guid value) => Value = value;

    // static factory method
    public static TransactionType CreateUnique() => new TransactionType(new Guid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}