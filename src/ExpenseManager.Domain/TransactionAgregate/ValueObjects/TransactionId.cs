using ExpenseManager.Domain.Common.Models;

namespace ExpenseManager.Domain.TransactionAggregate.ValueObjects;
public class TransactionId : ValueObject
{
    public Guid Value { get; }

    private TransactionId(Guid value) => Value = value;

    // static factory method
    public static TransactionId CreateUnique()
    {
        TransactionId transactionId = new(Guid.NewGuid());
        return transactionId; 
    } 

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}