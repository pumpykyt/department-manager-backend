using DepartmentManager.Domain.Interfaces;
using DepartmentManager.Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest model) => Ok(await _authService.LoginAsync(model));
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest model) => Ok(await _authService.RegisterAsync(model));

    [HttpGet]
    public async Task<IActionResult> GetUsers() => Ok(await _authService.GetUsersAsync());

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUser([FromRoute] string userId) => Ok(await _authService.GetUserAsync(userId));
}