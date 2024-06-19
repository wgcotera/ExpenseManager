using ErrorOr;
using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.PeriodAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

using MediatR;

namespace ExpenseManager.Application.Periods.Commands.CreatePeriod;
public class CreatePeriodCommandHandler : IRequestHandler<CreatePeriodCommand, ErrorOr<Period>>
{
    private readonly IPeriodRepository _periodRepository;

    public CreatePeriodCommandHandler(IPeriodRepository periodRepository)
    {
        _periodRepository = periodRepository;
    }
    public async Task<ErrorOr<Period>> Handle(CreatePeriodCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // Create a new period
        var period = Period.Create(
            userId: UserId.Create(command.UserId),
            startDate: command.StartDate,
            endDate: command.EndDate
        );

        // Persist the period
        _periodRepository.Add(period);

        // Return the period
        return period;
    }
}