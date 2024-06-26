using ExpenseManager.Application.Transactions.Commands.CreateTransaction;
using ExpenseManager.Contracts.Transactions;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.Api.Controllers;

[Route("users/{userId}/periods/{periodId}/transactions")]
public class TransactionsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public TransactionsController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction(
        [FromRoute] string periodId,
        [FromBody] CreateTransactionRequest request)
    {
        var command = _mapper.Map<CreateTransactionCommand>((request, periodId));
        var createTransactionResult = await _mediator.Send(command);

        return createTransactionResult.Match(
            transaction => Ok(_mapper.Map<TransactionResponse>(transaction)),
            errors => Problem(errors)
        );
    }
}