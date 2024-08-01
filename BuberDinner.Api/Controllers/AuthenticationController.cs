using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
public class AuthenticationContoller : ApiController
{

    private readonly IAuthenticationService authenticationService;

    public AuthenticationContoller(IAuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthenticationResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {

        ErrorOr<AuthenticationResult> authResult = authenticationService.Login(
            request.Email,
            request.Password);

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