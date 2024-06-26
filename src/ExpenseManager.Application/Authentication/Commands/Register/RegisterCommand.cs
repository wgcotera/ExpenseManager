using ErrorOr;

using ExpenseManager.Application.Common.Authentication;

using MediatR;

namespace ExpenseManager.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;