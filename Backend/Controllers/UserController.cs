using System.Security.Claims;
using BookingApplication.Models;
using BookingApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
    {
        try
        {
            var user = await userService.RegisterAsync(request);
            if (user == null)
                return BadRequest("Invalid request");
            return Ok();
        }
        catch (IdentityException ex)
        {
            return BadRequest(ex.Message);
        }
        catch
        {
            return StatusCode(500, new { errors = "An unexpected error occured." });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] SignInUserRequest request)
    {
        try
        {
            await userService.LoginAsync(request);

            return Ok();
        }
        catch (ArgumentNullException)
        {
            return BadRequest("User not found");
        }
        catch (IdentityException ex)
        {
            return Unauthorized(ex.Message);
        }
        catch
        {
            return StatusCode(500, new { errors = "An unexpected error occured." });
        }
    }

    // Option 1
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(string id, EditUserRequest request)
    {
        var user = await userService.GetByIdAsync(id);
        if (user == null || user.Id != User.FindFirstValue(ClaimTypes.NameIdentifier))
        {
            return BadRequest("");
        }
        return Ok();
    }

    // Option 2
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update(EditUserRequest request)
    {
        // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception();
        // var user = await userService.GetByIdAsync(userId);

        var updatedUser = await userService.EditFromRequestAsync(request);

        return Ok();
    }
}

public class SignInUserRequest : IRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class RegisterUserRequest : IRequest
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
}

public class EditUserRequest : IRequest
{
    public required string Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
}
