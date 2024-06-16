namespace ExpenseManager.Contracts.Authentication;
public record AuthenticationResponse(
    string Id,
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Token);