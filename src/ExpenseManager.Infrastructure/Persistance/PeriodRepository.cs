using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.PeriodAggregate;

namespace ExpenseManager.Infrastructure.Persistance;
public class PeriodRepository : IPeriodRepository
{
    private static readonly List<Period> _periods = new();

    public void Add(Period period)
    {
        _periods.Add(period);
    }

    public List<Period> GetAll()
    {
        return _periods;
    }
}