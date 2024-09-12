using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Users;

namespace BuberDinner.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{

    private readonly BubberDinnerDbContext _dbContext;

    public UserRepository(BubberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public User? GetUserByEmail(string email)
    {
        return _dbContext.Users.SingleOrDefault(user => user.Email.Equals(email));
    }
}