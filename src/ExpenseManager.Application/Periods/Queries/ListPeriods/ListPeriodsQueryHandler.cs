using ErrorOr;

using ExpenseManager.Application.Authentication.Queries.ListPeriods;
using ExpenseManager.Application.Common.Interfaces.Persistence;
using ExpenseManager.Domain.PeriodAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

using MediatR;

namespace ExpenseManager.Application.Periods.Queries.ListPeriods;

public class ListPeriodsQueryHandler : IRequestHandler<ListPeriodsQuery, ErrorOr<IEnumerable<Period>>>
{
    private readonly IPeriodRepository _periodRepository;

    public ListPeriodsQueryHandler(IPeriodRepository periodRepository)
    {
        _periodRepository = periodRepository;
    }

    public async Task<ErrorOr<IEnumerable<Period>>> Handle(ListPeriodsQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var userId = UserId.Create(query.UserId);
        var periods = _periodRepository.GetByUserId(userId);

        return periods;
    }
}