using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.RecurringTransactionAggregate;
using ExpenseManager.Domain.RecurringTransactionAggregate.ValueObjects;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Infrastructure.Persistence.Repositories;

public class RecurringTransactionRepository : IRecurringTransactionRepository
{
    private readonly ExpenseManagerDBContext _dbContext;

    public RecurringTransactionRepository(ExpenseManagerDBContext context)
    {
        _dbContext = context;
    }

    // Queries
    public List<RecurringTransaction> GetByUserId(UserId userId)
    {
        return _dbContext
            .RecurringTransactions
            .Where(recurringTransaction => recurringTransaction.UserId == userId)
            .ToList();
    }

    public RecurringTransaction? GetRecurringTransactionById(RecurringTransactionId recurringTransactionId)
    {
        return _dbContext.RecurringTransactions.FirstOrDefault(rt => rt.Id == recurringTransactionId);
    }

    // Commands
    public void Add(RecurringTransaction recurringTransaction)
    {
        _dbContext.Add(recurringTransaction);
        _dbContext.SaveChanges();
    }

    public void UpdateRecurringTransaction(RecurringTransaction recurringTransaction)
    {
        _dbContext.Update(recurringTransaction);
        _dbContext.SaveChanges();
    }
}