using System.Security.Claims;
using BookingApplication.Exceptions;
using BookingApplication.Models.Dtos;
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
            var user = await userService.CreateFromRequestAsync(request);
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

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update([FromBody] EditUserRequest request)
    {
        try
        {
            var userId =
                User.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? throw new Exception("Cannot retrieve user id.");
            request.Id = Guid.Parse(userId);

            var updatedUser = await userService.EditFromRequestAsync(request);

            return Ok();
        }
        catch
        {
            return StatusCode(500, new { errors = "An unexpected error occured." });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        try
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new Exception();
            await userService.DeleteAsync(userId);

            return NoContent();
        }
        catch
        {
            return StatusCode(500, new { errors = "An unexpected error occured." });
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await userService.DeleteAsync(id);

            return NoContent();
        }
        catch
        {
            return BadRequest($"Unable to delete user with id: {id}");
        }
    }
}
