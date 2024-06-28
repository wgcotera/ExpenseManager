namespace ExpenseManager.Contracts.Authentication;
public record RegisterRequest(
    string FirstName,
    string LastName,
    string Username,
    string Email,
    string Password);