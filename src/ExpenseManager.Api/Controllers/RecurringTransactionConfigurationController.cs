using ExpenseManager.Application.RecurringTransactionConfigurations.Commands;
using ExpenseManager.Contracts.RecurringTransactionConfiguration;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.Api.Controllers;

[Route("users/{userId}/recurring-transaction-configurations")]
public class RecurringTransactionConfigurationController : ApiController
{
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public RecurringTransactionConfigurationController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    public async Task<IActionResult> CreateRecurringTransactionConfiguration(
        [FromBody] CreateRecurringTransactionConfigurationRequest request,
        [FromRoute] string userId)
    {
        await Task.CompletedTask;

        var command = _mapper.Map<CreateRecurringTransactionConfigurationCommand>((request, userId));
        var createRecurringTransactionConfigurationResult = await _mediator.Send(command);

        return createRecurringTransactionConfigurationResult.Match(
            recurringTransactionConfiguration => Ok(_mapper
                .Map<RecurringTransactionConfigurationResponse>(recurringTransactionConfiguration)),
            errors => Problem(errors)
        );
    }

}