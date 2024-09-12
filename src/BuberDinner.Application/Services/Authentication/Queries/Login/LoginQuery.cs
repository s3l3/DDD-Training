using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Services.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;