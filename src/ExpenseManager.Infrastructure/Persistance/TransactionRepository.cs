using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.TransactionAggregate;

namespace ExpenseManager.Infrastructure.Persistance;
public class TransactionRepository : ITransactionRepository
{
    private static readonly List<Transaction> _transactions = new();

    public void Add(Transaction transaction)
    {
        _transactions.Add(transaction);
    }

    // public List<Transaction> GetByPeriodId(PeriodId periodId)
    // {
    //     return _transactions.FindAll(t => t.PeriodId == periodId);
    // }
}