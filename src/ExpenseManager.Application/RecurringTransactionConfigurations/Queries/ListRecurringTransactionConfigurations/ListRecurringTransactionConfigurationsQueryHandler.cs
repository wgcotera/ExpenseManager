using ErrorOr;

using ExpenseManager.Application.Common.Interfaces.Persistence;

using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

using MediatR;

namespace ExpenseManager.Application.RecurringTransactionConfigurations.Queries.ListRecurringTransactionConfigurations
{
    public class ListRecurringTransactionConfigurationsQueryHandler :
        IRequestHandler<ListRecurringTransactionConfigurationsQuery, ErrorOr<IEnumerable<RecurringTransactionConfiguration>>>
    {
        private readonly IRecurringTransactionConfigurationRepository _recurringTransactionConfigurationRepository;

        public ListRecurringTransactionConfigurationsQueryHandler(
            IRecurringTransactionConfigurationRepository recurringTransactionConfigurationRepository)
        {
            _recurringTransactionConfigurationRepository = recurringTransactionConfigurationRepository;
        }

        public async Task<ErrorOr<IEnumerable<RecurringTransactionConfiguration>>> Handle(
            ListRecurringTransactionConfigurationsQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            UserId userId = UserId.Create(query.UserId);
            var recurringTransactionConfigurations = _recurringTransactionConfigurationRepository.GetByUserId(userId);

            return recurringTransactionConfigurations;
        }

    }
}