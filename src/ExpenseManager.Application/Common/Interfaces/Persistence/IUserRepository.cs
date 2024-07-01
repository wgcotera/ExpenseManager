using ExpenseManager.Domain.UserAggregate;
using ExpenseManager.Domain.UserAggregate.ValueObjects;

namespace ExpenseManager.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    // Queries
    User? GetUserByEmail(string email);
    User? GetUserById(UserId userId);

    // Commands
    void Add(User user);
    void UpdateUser(User user);
}