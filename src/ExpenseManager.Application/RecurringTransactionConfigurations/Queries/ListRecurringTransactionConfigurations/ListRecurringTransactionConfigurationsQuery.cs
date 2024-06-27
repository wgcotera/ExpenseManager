using ErrorOr;

using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate;

using MediatR;

namespace ExpenseManager.Application.RecurringTransactionConfigurations.Queries.ListRecurringTransactionConfigurations;
public record ListRecurringTransactionConfigurationsQuery(string UserId) : IRequest<ErrorOr<IEnumerable<RecurringTransactionConfiguration>>>;