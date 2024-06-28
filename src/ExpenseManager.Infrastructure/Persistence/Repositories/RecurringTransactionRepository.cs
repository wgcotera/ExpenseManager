using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.RecurringTransactionAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Infrastructure.Persistence.Repositories;

public class RecurringTransactionRepository : IRecurringTransactionRepository
{
    private readonly ExpenseManagerDBContext _dbContext;

    public RecurringTransactionRepository(ExpenseManagerDBContext context)
    {
        _dbContext = context;
    }

    public void Add(RecurringTransaction recurringTransaction)
    {
        _dbContext.Add(recurringTransaction);
        _dbContext.SaveChanges();
    }

    public List<RecurringTransaction> GetByUserId(UserId userId)
    {
        return _dbContext
            .RecurringTransactions
            .Where(recurringTransaction => recurringTransaction.UserId == userId)
            .ToList();
    }
}