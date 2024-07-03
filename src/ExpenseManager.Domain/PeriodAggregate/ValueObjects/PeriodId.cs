using ErrorOr;

using ExpenseManager.Domain.Common.DomainErrors;
using ExpenseManager.Domain.Common.Models;

namespace ExpenseManager.Domain.PeriodAggregate.ValueObjects;
public class PeriodId : ValueObject
{
    public Guid Value { get; }

    private PeriodId(Guid value)
    {
        Value = value;
    }

    // static factory method
    public static PeriodId CreateUnique()
    {
        PeriodId periodId = new(Guid.NewGuid());
        return periodId;
    }

    public static PeriodId Create(string value)
    {
        return new PeriodId(Guid.Parse(value));
    }

    public static PeriodId Create(Guid periodId)
    {
        return new PeriodId(periodId);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}