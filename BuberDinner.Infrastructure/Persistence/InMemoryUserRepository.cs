using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class InMemoryUserRepository : IUserRepository
{
    private static readonly List<User> users = new();

    public void Add(User user)
    {
        users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return users.SingleOrDefault(user => user.Email.Equals(email));
    }
}