using ExpenseManager.Domain.Common.Models;
using ExpenseManager.Domain.PeriodAggregate.ValueObjects;
using ExpenseManager.Domain.RecurringTransactionConfigurationAggregate.ValueObjects;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Domain.UserAggregate;
public class User : AggregateRoot<UserId>
{
    private readonly List<PeriodId> _periodIds = new();
    private readonly List<RecurringTransactionConfigurationId> _recurringTransactionConfigurationIds = new();

    public string FirstName { get; }
    public string LastName { get; }
    public string UserName { get; }
    public string Email { get; }
    public string Password { get; }

    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public IReadOnlyList<PeriodId> PeriodIds => _periodIds.AsReadOnly();
    public IReadOnlyList<RecurringTransactionConfigurationId> RecurringTransactionConfigurationIds => _recurringTransactionConfigurationIds.AsReadOnly();

    private User(
        string firstName,
        string lastName,
        string username,
        string email,
        string password,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        UserId? userId = null) : base(userId ?? UserId.CreateUnique())
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = username;
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
            firstName,
            lastName,
            username,
            email,
            password,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}