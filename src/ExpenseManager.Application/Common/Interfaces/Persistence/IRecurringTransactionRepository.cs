
using ErrorOr;

using ExpenseManager.Domain.RecurringTransactionAggregate;
using ExpenseManager.Domain.RecurringTransactionAggregate.ValueObjects;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Application.Common.Interfaces.Persistence;

public interface IRecurringTransactionRepository
{
    // Queries
    List<RecurringTransaction> GetByUserId(UserId userId);
    RecurringTransaction? GetRecurringTransactionById(RecurringTransactionId recurringTransactionId);

    // Commands
    void Add(RecurringTransaction recurringTransaction);
    void UpdateRecurringTransaction(RecurringTransaction recurringTransaction);

}