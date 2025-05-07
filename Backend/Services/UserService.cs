using BookingApplication.Models;
using Microsoft.AspNetCore.Identity;

namespace BookingApplication.Services;

public interface IUserService
{
    public Task<AppUser> RegisterAsync();
    public Task<AppUser> LoginAsync();
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

    public Task<AppUser> LoginAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AppUser> RegisterAsync()
    {
        throw new NotImplementedException();
    }

    public Task<AppUser> UpdateAsync()
    {
        throw new NotImplementedException();
    }
}
