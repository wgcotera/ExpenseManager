using ErrorOr;
using ExpenseManager.Domain.Common.Authentication;
using MediatR;

namespace ExpenseManager.Application.Authentication.Queries.Login;

public record LoginQuery
(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
