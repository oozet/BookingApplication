using System.Security.Claims;
using BookingApplication.Exceptions;
using BookingApplication.Models.Dtos;
using BookingApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;

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
            var response = await userService.LoginAsync(request);

            return Ok(response);
        }
        catch (ArgumentNullException)
        {
            return BadRequest(new { errors = "User not found" });
        }
        catch (IdentityException ex)
        {
            return Unauthorized(new { errors = ex.Message });
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
        catch (Exception ex)
        {
            Console.WriteLine(ex);
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPublicUserInfo(string id)
    {
        try
        {
            var user = await userService.GetByIdAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(new
            {
                user.UserName
            });
        }
        catch
        {
            return BadRequest();
        }
    }


    [HttpGet("is-admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult IsAdmin()
    {
        return Ok();
    }

    [HttpGet("bookings")]
    [Authorize]
    public async Task<IActionResult> GetMyBookings()
    {
        try
        {
            Console.WriteLine("Endpoint hit - checking user claims...");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Console.WriteLine($"User ID from claims: {userId}");

            if (userId == null)
                throw new Exception("Cannot retrieve user id.");

            Console.WriteLine($"Calling service with GUID: {Guid.Parse(userId)}");
            var bookings = await userService.GetBookingsByUserAsync(Guid.Parse(userId));

            Console.WriteLine($"Retrieved {bookings?.Count() ?? 0} bookings");
            return Ok(bookings);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Full exception: {ex}");
            return StatusCode(500, new { errors = "An unexpected error occurred." });
        }
    }

}
