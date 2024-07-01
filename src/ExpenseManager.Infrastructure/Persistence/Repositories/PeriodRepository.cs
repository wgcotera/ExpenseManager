using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.PeriodAggregate;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Infrastructure.Persistence.Repositories;
public class PeriodRepository : IPeriodRepository
{

    private readonly ExpenseManagerDBContext _dbContext;

    public PeriodRepository(ExpenseManagerDBContext context)
    {
        _dbContext = context;
    }

    // Queries
    public List<Period> GetByUserId(UserId userId)
    {
        return _dbContext
            .Periods
            .Where(Period => Period.UserId == userId)
            .ToList();
    }

    public Period? GetPeriodById(PeriodId periodId)
    {
        return _dbContext.Periods.FirstOrDefault(p => p.Id == periodId);
    }

    // Commands
    public void Add(Period period)
    {
        _dbContext.Add(period);
        _dbContext.SaveChanges();
    }

    public void UpdatePeriod(Period period)
    {
        _dbContext.Update(period);
        _dbContext.SaveChanges();
    }
}