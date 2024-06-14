using BuberDinner.Domain.Common.Models;

namespace ExpenseManager.Domain.Period.ValueObjects;
public class PeriodId : ValueObject
{
    public Guid Value { get; }

    private PeriodId(Guid value) => Value = value;

    // static factory method
    public static PeriodId CreateUnique() => new PeriodId(new Guid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}