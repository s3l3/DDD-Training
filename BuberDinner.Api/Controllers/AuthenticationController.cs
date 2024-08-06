using BuberDinner.Application.Services.Authentication.Commands.Register;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Application.Services.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationContoller : ApiController
{
    private readonly ISender _mediatR;

    public AuthenticationContoller(ISender mediatR)
    {
        _mediatR = mediatR;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var registerCommand = new RegisterCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var authResult = await _mediatR.Send(registerCommand);

        return authResult.Match(
            authResult => Ok(MapAuthenticationResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var loginCommand = new LoginQuery(
            request.Email,
            request.Password);

        var authResult = await _mediatR.Send(loginCommand);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(MapAuthenticationResult(authResult)),
            errors => Problem(errors)
            );
    }

    private static AuthenticationResponse MapAuthenticationResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
    }
}