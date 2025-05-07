using Backend_ind.Services;
using BookingApplication.Controllers;
using BookingApplication.Interfaces;
using BookingApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;

namespace BookingApplication.Services;

public interface IUserService : IService<User, RegisterUserRequest, SignInUserRequest>
{
    public Task<User> RegisterAsync(RegisterUserRequest request);
    public Task LoginAsync(SignInUserRequest request);
    public Task DeleteAsync();
    public Task<User> UpdateAsync();

    // id, username
    //public Task<Dictionary<string, string>> GetAllAsync();
    public Task<User> GetByIdAsync(string id);
}

public class UserService : IUserService //: EfService<User, RegisterRequest, EditUserRequest>, IUserService
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;

    public UserService(UserManager<User> userManager, SignInManager<User> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    public Task<User> CreateFromRequestAsync(RegisterUserRequest request)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User entityToRemove)
    {
        throw new NotImplementedException();
    }

    public Task<User?> DeleteAsync(Guid entityId)
    {
        throw new NotImplementedException();
    }

    public Task EditAsync(User entityToEdit)
    {
        throw new NotImplementedException();
    }

    public Task<User> EditFromRequestAsync(SignInUserRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(Guid entityId)
    {
        throw new NotImplementedException();
    }

    public async Task LoginAsync(SignInUserRequest request)
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

    public Task LoginAsync(RegisterUserRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<User> RegisterAsync(RegisterUserRequest request)
    {
        var user = new User()
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

    public Task<User> UpdateAsync()
    {
        throw new NotImplementedException();
    }
}

public class IdentityException(string message) : Exception(message) { }
