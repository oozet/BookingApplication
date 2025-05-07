using BookingApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace BookingApplication.Services;

public interface IUserService
{
    public Task<AppUser> RegisterAsync(RegisterRequest request);
    public Task LoginAsync(SignInRequest request);
    public Task DeleteAsync();
    public Task<AppUser> UpdateAsync();

    // id, username
    public Task<Dictionary<string, string>> GetAllAsync();
    public Task<AppUser> GetByIdAsync(string id);
}

public class UserService : IUserService
{
    private readonly UserManager<AppUser> userManager;
    private readonly SignInManager<AppUser> signInManager;

    public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    public Task DeleteAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Dictionary<string, string>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AppUser> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task LoginAsync(SignInRequest request)
    {
        _ =
            await userManager.FindByNameAsync(request.Username)
            ?? throw new ArgumentNullException("User not found.");

        var result = await signInManager.PasswordSignInAsync(
            request.Username,
            request.Password,
            false,
            false
        );

        if (!result.Succeeded)
        {
            throw new IdentityException($"Invalid username or password");
        }

        return;
    }

    public async Task<AppUser> RegisterAsync(RegisterRequest request)
    {
        var user = new AppUser()
        {
            UserName = request.Username,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
        };
        var result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errorMessages = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new IdentityException($"Error while creating user: {errorMessages}");
        }
        return user;
    }

    public Task<AppUser> UpdateAsync()
    {
        throw new NotImplementedException();
    }
}

public class IdentityException(string message) : Exception(message) { }
