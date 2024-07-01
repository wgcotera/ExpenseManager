using ExpenseManager.Domain.Common.Models;
using ExpenseManager.Domain.Common.Models.Identities;

namespace ExpenseManager.Domain.PeriodAggregate.ValueObjects;
public class PeriodId : AggregateRootId<Guid>
{
    private PeriodId(Guid value) : base(value)
    {
    }

    // static factory method
    public static PeriodId CreateUnique()
    {
        PeriodId periodId = new(Guid.NewGuid());
        return periodId;
    }

    public static PeriodId Create(string periodId)
    {
        return new PeriodId(Guid.Parse(periodId));
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