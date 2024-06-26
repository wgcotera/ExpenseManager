using ExpenseManager.Domain.TransactionAggregate;

namespace ExpenseManager.Application.Common.Interfaces.Persistence;
public interface ITransactionRepository
{
    void Add(Transaction transaction);

    // List<Transaction> GetByPeriodId(PeriodId periodId);
}