
using ExpenseManager.Domain.PeriodAggregate.Events;

using MediatR;

namespace ExpenseManager.Application.Periods.Events;
public class PeriodCreatedHandler : INotificationHandler<PeriodCreated>
{
    public Task Handle(PeriodCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}