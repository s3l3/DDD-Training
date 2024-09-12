using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Users.ValueObjects;

namespace BuberDinner.Domain.Users;

public sealed class User : AggregateRoot<UserId, Guid>
{
    public string Email { get; private set; }

    public string Password { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public DateTime CreatedDateTime { get; private set; }

    public DateTime UpdatedDateTime { get; private set; }

#pragma warning disable CS8618
    private User() { }
#pragma warning restore CS8618

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