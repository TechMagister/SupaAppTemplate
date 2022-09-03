using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupabaseAuth;
using TechMagister.Starter.Auth;
using TechMagister.Starter.WebApi.Requests;

namespace TechMagister.Starter.WebApi.Controllers;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService authService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _authService = authService ?? throw new ArgumentNullException(nameof(authService));
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<Session> Login(LoginRequest req)
    {
        var session = await _authService.SignInAsync(req.Email!, req.Password!);
        _logger.LogDebug("User {Email} signed in", req.Email);
        return session;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<Session> Register(RegisterRequest req)
    {
        var session = await _authService.SignUpAsync(req.Email!, req.Password!);
        _logger.LogDebug("User {Email} registered", req.Email);
        return session;
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task Logout()
    {
        var accessToken = HttpContext.Request.Headers.Authorization
            .FirstOrDefault()?.Replace("Bearer ", "");
        await _authService.SignOutAsync(accessToken);
    }
}
