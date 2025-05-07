using BookingApplication.Models;
using BookingApplication.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Controllers;

[ApiController]
[Route("")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;
    private readonly SignInManager<IdentityUser> signInManager;
    private readonly UserManager<IdentityUser> userManager;

    public UserController(
        IUserService userService,
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager
    )
    {
        this.userService = userService;
        this.signInManager = signInManager;
        this.userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        try
        {
            var user = new IdentityUser()
            {
                UserName = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            };
            var result = await userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                // Return an array of possible errors from UserManager to be handled and displayed on frontend.
                return BadRequest(new { errors = result.Errors.Select(e => e.Description) });
            }
            return Ok();
        }
        catch
        {
            return StatusCode(500, new { errors = "An unexpected error occured." });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> SignIn(SignInRequest request)
    {
        try
        {
            // Could use UserManager to give different error if the username doesn't exist in database.

            var result = await signInManager.PasswordSignInAsync(
                request.Username,
                request.Password,
                false,
                false
            );
            if (!result.Succeeded)
            {
                // Logic for different results?
            }
            return Ok();
        }
        catch
        {
            return Unauthorized("Invalid credentials");
        }
    }
}
