using ExpenseManager.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManager.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        return Ok(request);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        return Ok(request);
    }
}