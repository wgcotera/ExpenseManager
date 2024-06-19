using ErrorOr;
using ExpenseManager.Domain.PeriodAggregate;
using MediatR;

namespace ExpenseManager.Application.Authentication.Queries.ListPeriods;

public record ListPeriodsQuery
(
    string UserId) : IRequest<ErrorOr<IEnumerable<Period>>>;