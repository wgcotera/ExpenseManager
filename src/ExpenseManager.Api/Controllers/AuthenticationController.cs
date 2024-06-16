using ErrorOr;
using ExpenseManager.Application.Authentication.Commands.Register;
using ExpenseManager.Contracts.Authentication;
using ExpenseManager.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.UserName,
            request.Email,
            request.Password);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
        return authResult.Match<IActionResult>(
            Ok,
            BadRequest);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        return Ok(request);
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id.Value,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Username,
            authResult.User.Email,
            authResult.Token);
    }
}