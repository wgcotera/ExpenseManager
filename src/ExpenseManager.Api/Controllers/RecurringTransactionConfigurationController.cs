using ExpenseManager.Application.RecurringTransactionConfigurations.Commands;
using ExpenseManager.Application.RecurringTransactionConfigurations.Queries.ListRecurringTransactionConfigurations;
using ExpenseManager.Contracts.RecurringTransactionConfiguration;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.Api.Controllers;

[Route("users/{userId}/recurring-transaction-configurations")]
public class RecurringTransactionConfigurationController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public RecurringTransactionConfigurationController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecurringTransactionConfiguration(
        [FromBody] CreateRecurringTransactionConfigurationRequest request,
        [FromRoute] string userId)
    {
        var command = _mapper.Map<CreateRecurringTransactionConfigurationCommand>((request, userId));
        var createRecurringTransactionConfigurationResult = await _mediator.Send(command);

        return createRecurringTransactionConfigurationResult.Match(
            recurringTransactionConfiguration => Ok(_mapper
                .Map<RecurringTransactionConfigurationResponse>(recurringTransactionConfiguration)),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> ListRecurringTransactionConfigurations(
        [FromRoute] string userId)
    {
        var query = _mapper.Map<ListRecurringTransactionConfigurationsQuery>(userId);
        var listRecurringTransactionConfigurationsResult = await _mediator.Send(query);

        return listRecurringTransactionConfigurationsResult.Match(
            recurringTransactionConfigurations => Ok(recurringTransactionConfigurations
                .Select(recurringTransactionConfiguration => _mapper
                    .Map<RecurringTransactionConfigurationResponse>(recurringTransactionConfiguration))),
            errors => Problem(errors)
        );
    }

}