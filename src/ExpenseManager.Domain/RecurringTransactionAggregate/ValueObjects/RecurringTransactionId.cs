using ExpenseManager.Domain.Common.Models;
using ExpenseManager.Domain.Common.Models.Identities;

namespace ExpenseManager.Domain.RecurringTransactionAggregate.ValueObjects;

public class RecurringTransactionId : AggregateRootId<Guid>
{

    private RecurringTransactionId(Guid value) : base(value)
    {
    }

    // static factory method
    public static RecurringTransactionId CreateUnique()
    {
        RecurringTransactionId recurringTransactionId = new(Guid.NewGuid());
        return recurringTransactionId;
    }

    public static RecurringTransactionId Create(string recurringTransactionId)
    {
        return new RecurringTransactionId(Guid.Parse(recurringTransactionId));
    }

    public static RecurringTransactionId Create(Guid recurringTransactionId)
    {
        return new RecurringTransactionId(recurringTransactionId);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
