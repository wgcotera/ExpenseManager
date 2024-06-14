using BuberDinner.Domain.Common.Models;

namespace ExpenseManager.Domain.Transaction.ValueObjects;
public class TransactionId : ValueObject
{
    public Guid Value { get; }

    private TransactionId(Guid value) => Value = value;

    // static factory method
    public static TransactionId CreateUnique() => new TransactionId(new Guid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}