using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.PeriodAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Infrastructure.Persistence;
public class PeriodRepository : IPeriodRepository
{
    private static readonly List<Period> _periods = new();

    public void Add(Period period)
    {
        _periods.Add(period);
    }

    public List<Period> GetByUserId(UserId userId)
    {
        return _periods.FindAll(p => p.UserId == userId);
    }

}