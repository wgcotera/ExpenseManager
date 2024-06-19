using ExpenseManager.Domain.Common.Models;

namespace ExpenseManager.Domain.RecurringTransactionConfigurationAggregate.ValueObjects;
public class Frequency : ValueObject
{
    public Guid Value { get; }

    private Frequency(Guid value) => Value = value;

    // static factory method
    public static Frequency CreateUnique() => new Frequency(new Guid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}