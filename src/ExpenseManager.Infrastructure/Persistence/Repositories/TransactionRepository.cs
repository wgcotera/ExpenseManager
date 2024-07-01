using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.TransactionAggregate;
using ExpenseManager.Domain.TransactionAggregate.ValueObjects;

namespace ExpenseManager.Infrastructure.Persistence.Repositories;
public class TransactionRepository : ITransactionRepository
{
    private readonly ExpenseManagerDBContext _dbContext;

    public TransactionRepository(ExpenseManagerDBContext context)
    {
        _dbContext = context;
    }

    // Queries
    public List<Transaction> GetByPeriodId(PeriodId periodId)
    {
        return _dbContext
            .Transactions
            .Where(transaction => transaction.PeriodId == periodId)
            .ToList();
    }

    public Transaction? GetTransactionById(TransactionId transactionId)
    {
        return _dbContext.Transactions.FirstOrDefault(t => t.Id == transactionId);
    }

    public void Add(Transaction transaction)
    {
        _dbContext.Add(transaction);
        _dbContext.SaveChanges();
    }

    public void UpdateTransaction(Transaction transaction)
    {
        _dbContext.Update(transaction);
        _dbContext.SaveChanges();
    }
}