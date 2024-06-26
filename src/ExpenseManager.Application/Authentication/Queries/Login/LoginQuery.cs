using ErrorOr;

using ExpenseManager.Application.Common.Authentication;

using MediatR;

namespace ExpenseManager.Application.Authentication.Queries.Login;

public record LoginQuery
(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
