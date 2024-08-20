using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.User;

public class User : AggregateRoot<UserId>
{
    public string Email { get; }
    public string Password { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    private User(
        UserId userId,
        string email,
        string password,
        string firstName,
        string lastName,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(userId)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static User Create(string email,
        string password,
        string firstName,
        string lastName)
    {
        return new(
            UserId.CreateUnique(),
            email,
            password,
            firstName,
            lastName,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}