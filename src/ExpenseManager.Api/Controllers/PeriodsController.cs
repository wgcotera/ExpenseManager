using ExpenseManager.Application.Periods.Commands.CreatePeriod;
using ExpenseManager.Contracts.Periods;
using ExpenseManager.Domain.Common.DomainErrors;
using ExpenseManager.Domain.PeriodAggregate;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.Api.Controllers;

[Route("users/{userId}/periods")]
public class PeriodsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public PeriodsController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePeriod(
        string userId,
        CreatePeriodRequest request)
    {
        await Task.CompletedTask;
    
        var command = _mapper.Map<CreatePeriodCommand>((request, userId));
        var createPeriodResult = await _mediator.Send(command);

        return createPeriodResult.Match(
            period => Ok(_mapper.Map<PeriodResponse>(period)),
            errors => Problem(errors)
        );

    }
}