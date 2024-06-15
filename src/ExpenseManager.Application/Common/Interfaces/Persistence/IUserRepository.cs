using ExpenseManager.Domain.UserAggregate;

namespace ExpenseManager.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}