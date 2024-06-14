using ExpenseManager.Domain.Common.Models;
using ExpenseManager.Domain.Period.ValueObjects;
using ExpenseManager.Domain.User.ValueObjects;

namespace ExpenseManager.Domain.User;
public class User : AggregateRoot<UserId>
{
    private List<PeriodId> _periodIds = new();

    public string FirstName { get; }
    public string LastName { get; }
    public string Username { get; }
    public string Email { get; }
    public string Password { get; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public IReadOnlyList<PeriodId> PeriodIds => _periodIds.AsReadOnly();

    private User(
        UserId userId,
        string firstName,
        string lastName,
        string username,
        string email,
        string password,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Email = email;
        Password = password;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static User Create(
        string firstName,
        string lastName,
        string username,
        string email,
        string password)
    {
        return new User(
            UserId.CreateUnique(),
            firstName,
            lastName,
            username,
            email,
            password,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}