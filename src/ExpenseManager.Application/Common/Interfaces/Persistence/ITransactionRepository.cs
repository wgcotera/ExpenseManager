using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.TransactionAggregate;

namespace ExpenseManager.Application.Common.Interfaces.Persistence;
public interface ITransactionRepository
{
    // Queries
    List<Transaction> GetByPeriodId(PeriodId periodId);

    // Commands
    void Add(Transaction transaction);
    void UpdateTransaction(Transaction transaction);
}