using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.TransactionAggregate;

namespace ExpenseManager.Infrastructure.Persistence.Repositories;
public class TransactionRepository : ITransactionRepository
{
    private readonly ExpenseManagerDBContext _dbContext;

    public TransactionRepository(ExpenseManagerDBContext context)
    {
        _dbContext = context;
    }

    public void Add(Transaction transaction)
    {
        _dbContext.Add(transaction);
        _dbContext.SaveChanges();
    }

    public List<Transaction> GetByPeriodId(PeriodId periodId)
    {
        return _dbContext
            .Transactions
            .Where(transaction => transaction.PeriodId == periodId)
            .ToList();
    }
}