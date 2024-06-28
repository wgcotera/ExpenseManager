using ExpenseManager.Application.RecurringTransactions.Commands.CreateRecurringTransaction;
using ExpenseManager.Application.RecurringTransactions.Queries.ListRecurringTransactions;
using ExpenseManager.Contracts.RecurringTransaction;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.Api.Controllers;

[Route("users/{userId}/recurring-transaction-configurations")]
public class RecurringTransactionController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public RecurringTransactionController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecurringTransaction(
        [FromBody] CreateRecurringTransactionRequest request,
        [FromRoute] string userId)
    {
        var command = _mapper.Map<CreateRecurringTransactionCommand>((request, userId));
        var createRecurringTransactionResult = await _mediator.Send(command);

        return createRecurringTransactionResult.Match(
            recurringTransaction => Ok(_mapper
                .Map<RecurringTransactionResponse>(recurringTransaction)),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> ListRecurringTransactions(
        [FromRoute] string userId)
    {
        var query = _mapper.Map<ListRecurringTransactionsQuery>(userId);
        var listRecurringTransactionsResult = await _mediator.Send(query);

        return listRecurringTransactionsResult.Match(
            recurringTransactions => Ok(recurringTransactions
                .Select(recurringTransaction => _mapper
                    .Map<RecurringTransactionResponse>(recurringTransaction))),
            errors => Problem(errors)
        );
    }

}