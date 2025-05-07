using BookingApplication.Models;
using BookingApplication.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Controllers;

[ApiController]
[Route("user")]
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
    public async Task<IActionResult> Login(SignInRequest request)
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