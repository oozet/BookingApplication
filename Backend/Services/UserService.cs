using BookingApplication.Controllers;
using BookingApplication.Interfaces;
using BookingApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace BookingApplication.Services;

public interface IUserService : IService<User, RegisterUserRequest, EditUserRequest>
{
    public Task<User> RegisterAsync(RegisterUserRequest request);
    public Task LoginAsync(SignInUserRequest request);

    // id, username
    //public Task<Dictionary<string, string>> GetAllAsync();
    public Task<User?> GetByIdAsync(string id);
}

public class UserService : IUserService //: EfService<User, RegisterRequest, EditUserRequest>, IUserService
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;

    //private readonly EntityUpdaterService updaterService;

    public UserService(
        UserManager<User> userManager,
        SignInManager<User> signInManager
    //EntityUpdaterService updaterService
    )
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        //this.updaterService = updaterService;
    }

    public Task<User> CreateFromRequestAsync(RegisterUserRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(User entityToRemove)
    {
        await userManager.DeleteAsync(entityToRemove);
        return;
    }

    public async Task<User?> DeleteAsync(Guid entityId)
    {
        var user = await userManager.FindByIdAsync(entityId.ToString());
        if (user == null)
            return null;

        var result = await userManager.DeleteAsync(user);
        if (result.Succeeded)
            return null;

        throw new IdentityException($"Unable to delete {user.UserName}");
    }

    public async Task EditAsync(User entityToEdit)
    {
        var result = await userManager.UpdateAsync(entityToEdit);
        if (result.Succeeded)
            return;

        throw new IdentityException($"Unable to update {entityToEdit.UserName}");
    }

    public async Task<User> EditFromRequestAsync(EditUserRequest request)
    {
        var user =
            await userManager.FindByIdAsync(request.Id)
            ?? throw new ArgumentNullException($"Unable to find user with id {request.Id}");

        //updaterService.UpdateEntity(user, request);

        var result = await userManager.UpdateAsync(user);
        if (result.Succeeded)
            return user;

        throw new IdentityException($"Unable to update {user.UserName}");
    }

    // Implement with pagination?
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await userManager.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        return await userManager.FindByIdAsync(id);
    }

    public async Task<User?> GetByIdAsync(Guid entityId)
    {
        return await userManager.FindByIdAsync(entityId.ToString());
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
}

public class IdentityException(string message) : Exception(message) { }

// public interface IEntityUpdaterService
// {
//     void UpdateEntity<T>(T entity, object updateRequest)
//         where T : class;
// }

// public class EntityUpdaterService : IEntityUpdaterService
// {
//     public void UpdateEntity<T>(T entity, object updateRequest)
//         where T : class
//     {
//         var entityType = entity.GetType();
//         var requestType = updateRequest.GetType();

//         foreach (var prop in requestType.GetProperties())
//         {
//             var entityProp = entityType.GetProperty(prop.Name);
//             if (entityProp != null && entityProp.CanWrite)
//             {
//                 var newValue = prop.GetValue(updateRequest);
//                 if (newValue != null) // Only update non-null values
//                 {
//                     entityProp.SetValue(entity, newValue);
//                 }
//             }
//         }
//     }
// }
