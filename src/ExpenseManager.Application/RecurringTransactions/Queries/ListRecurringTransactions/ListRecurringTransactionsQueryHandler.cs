using ErrorOr;

using ExpenseManager.Application.Common.Interfaces.Persistence;

using ExpenseManager.Domain.RecurringTransactionAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

using MediatR;

namespace ExpenseManager.Application.RecurringTransactions.Queries.ListRecurringTransactions
{
    public class ListRecurringTransactionsQueryHandler :
        IRequestHandler<ListRecurringTransactionsQuery, ErrorOr<IEnumerable<RecurringTransaction>>>
    {
        private readonly IRecurringTransactionRepository _recurringTransactionRepository;

        public ListRecurringTransactionsQueryHandler(
            IRecurringTransactionRepository recurringTransactionRepository)
        {
            _recurringTransactionRepository = recurringTransactionRepository;
        }

        public async Task<ErrorOr<IEnumerable<RecurringTransaction>>> Handle(
            ListRecurringTransactionsQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            UserId userId = UserId.Create(query.UserId);
            var recurringTransactions = _recurringTransactionRepository.GetByUserId(userId);

            return recurringTransactions;
        }

    }
}