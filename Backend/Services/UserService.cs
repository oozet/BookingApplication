using BookingApplication.Controllers;
using BookingApplication.Exceptions;
using BookingApplication.Helpers;
using BookingApplication.Interfaces;
using BookingApplication.Models;
using BookingApplication.Models.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingApplication.Services;

public interface IUserService : IService<User, RegisterUserRequest, EditUserRequest>
{
    public Task<SignInUserResponse> LoginAsync(SignInUserRequest request);

    // id, username
    //public Task<Dictionary<string, string>> GetAllAsync();
    public Task<User?> GetByIdAsync(string id);
    public Task<User?> DeleteAsync(string entityId);
    Task<IEnumerable<Booking>> GetBookingsByUserAsync(Guid userId);
}

public class UserService : IUserService //: EfService<User, RegisterRequest, EditUserRequest>, IUserService
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly IRepository<Booking> bookingRepository;

    //private readonly EntityUpdaterService updaterService;

    public UserService(
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IRepository<Booking> bookingRepository
    //EntityUpdaterService updaterService
    )
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
         this.bookingRepository = bookingRepository;
        //this.updaterService = updaterService;
    }

    public async Task<User> CreateFromRequestAsync(RegisterUserRequest request)
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

    public async Task<User?> DeleteAsync(string entityId)
    {
        var user = await userManager.FindByIdAsync(entityId.ToString());
        if (user == null)
            return null;

        var result = await userManager.DeleteAsync(user);
        if (result.Succeeded)
            return null;

        throw new IdentityException($"Unable to delete {user.UserName}");
    }

    public async Task DeleteAsync(User entityToRemove)
    {
        var result = await userManager.DeleteAsync(entityToRemove);
        if (result.Succeeded)
            return;

        throw new IdentityException($"Unable to delete {entityToRemove.UserName}");
    }

    public Task<User?> DeleteAsync(Guid entityId)
    {
        throw new NotImplementedException();
    }

    public Task EditAsync(User entityToEdit)
    {
        throw new NotImplementedException();
    }

    public async Task<User> EditFromRequestAsync(EditUserRequest request)
    {
        // // Possible solution for updating User if nothing easier is found.
        var user =
            await userManager.FindByIdAsync(request.Id.ToString())
            ?? throw new ArgumentNullException($"Unable to find user with id {request.Id}");

        if (request.NewPassword != null)
        {
            await userManager.CheckPasswordAsync(user, request.Password ?? throw new IdentityException("Invalid password."));
        }

        user = EntityUpdaterHelper.UpdateEntity(user, request);
        // EntityUpdaterHelper.UpdateEntity<User>(user, request);

        var result = await userManager.UpdateAsync(user);
        if (result.Succeeded)
            return user;

        Console.WriteLine("Update failed for user {0}. Errors: {1}", user.Id, string.Join(", ", result.Errors.Select(e => e.Description)));

        throw new IdentityException($"Unable to update {user.UserName}");
    }

    // Implement with pagination if too many users
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await userManager.Users.ToListAsync();
    }

    public async Task<IEnumerable<Booking>> GetBookingsByUserAsync(Guid userId)
    {
        return await bookingRepository.GetBookingsByUserAsync(userId);
            }

    public async Task<User?> GetByIdAsync(string id)
    {
        return await userManager.FindByIdAsync(id);
    }

    public Task<User?> GetByIdAsync(Guid entityId)
    {
        throw new NotImplementedException();
    }

    public async Task<SignInUserResponse> LoginAsync(SignInUserRequest request)
    {
        var user =
            await userManager.FindByNameAsync(request.Username)
            ?? throw new IdentityException("Invalid username");

        var result = await signInManager.PasswordSignInAsync(
            request.Username,
            request.Password,
            false,
            false
        );

        if (result.Succeeded)
        {
            return new SignInUserResponse { Id = user.Id, Username = user.UserName! };
        }
        throw new IdentityException($"Invalid username or password");
    }

    Task IService<User, RegisterUserRequest, EditUserRequest>.DeleteAsync(Guid entityId)
    {
        return DeleteAsync(entityId);
    }
}