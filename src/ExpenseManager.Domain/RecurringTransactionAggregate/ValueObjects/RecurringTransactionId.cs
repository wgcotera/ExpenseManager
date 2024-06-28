using ExpenseManager.Domain.Common.Models;

namespace ExpenseManager.Domain.RecurringTransactionAggregate.ValueObjects;

public class RecurringTransactionId : ValueObject
{
    public Guid Value { get; }

    private RecurringTransactionId(Guid value) => Value = value;

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
