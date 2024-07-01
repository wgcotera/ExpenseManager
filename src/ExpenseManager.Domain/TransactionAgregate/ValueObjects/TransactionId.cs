using ExpenseManager.Domain.Common.Models.Identities;

namespace ExpenseManager.Domain.TransactionAggregate.ValueObjects;
public class TransactionId : AggregateRootId<Guid>
{

    private TransactionId(Guid value) : base(value)
    {
    }

    // static factory method
    public static TransactionId CreateUnique()
    {
        TransactionId transactionId = new(Guid.NewGuid());
        return transactionId;
    }

    public static TransactionId Create(string transactionId)
    {
        return new TransactionId(Guid.Parse(transactionId));
    }

    public static TransactionId Create(Guid transactionId)
    {
        return new TransactionId(transactionId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}