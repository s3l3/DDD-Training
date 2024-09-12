using BuberDinner.Domain.Users;

namespace BuberDinner.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token
);