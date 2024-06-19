using ErrorOr;

using ExpenseManager.Domain.PeriodAggregate;

using MediatR;

namespace ExpenseManager.Application.Periods.Commands.CreatePeriod;
public record CreatePeriodCommand(
    string UserId,
    DateTime StartDate,
    DateTime EndDate
) : IRequest<ErrorOr<Period>>;
