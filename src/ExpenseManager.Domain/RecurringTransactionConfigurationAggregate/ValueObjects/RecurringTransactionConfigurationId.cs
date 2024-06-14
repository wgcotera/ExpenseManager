using BuberDinner.Domain.Common.Models;

namespace ExpenseManager.Domain.RecurringTransactionConfigurationAggregate.ValueObjects;

public class RecurringTransactionConfigurationId : ValueObject
{
    public Guid Value { get; }

    private RecurringTransactionConfigurationId(Guid value) => Value = value;

    // static factory method
    public static RecurringTransactionConfigurationId CreateUnique() => new RecurringTransactionConfigurationId(new Guid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
