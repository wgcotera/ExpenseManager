using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.PeriodAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Infrastructure.Persistence.Repositories;
public class PeriodRepository : IPeriodRepository
{

    private readonly ExpenseManagerDBContext _dbContext;

    public PeriodRepository(ExpenseManagerDBContext context)
    {
        _dbContext = context;
    }
    public void Add(Period period)
    {
        _dbContext.Add(period);
        _dbContext.SaveChanges();
    }

    public List<Period> GetByUserId(UserId userId)
    {
        return _dbContext
            .Periods
            .Where(Period => Period.UserId == userId)
            .ToList();
    }
}