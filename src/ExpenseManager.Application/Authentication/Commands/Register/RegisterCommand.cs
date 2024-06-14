using ErrorOr;
using MediatR;
using ExpenseManager.Domain.Common;

namespace ExpenseManager.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;