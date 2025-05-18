using BookingApplication.Data;
using BookingApplication.Models;
using BookingApplication.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookingApplication;

public class Program
{
    public async static Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<BookingAppContext>(options =>
            options.UseNpgsql(DbConfig.connectionString)
        );

        builder
            .Services.AddIdentity<User, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<BookingAppContext>()
            .AddDefaultTokenProviders()
            .AddRoles<IdentityRole<Guid>>();

        builder.Services.AddControllers();
        builder.Services.AddScoped<IUserService, UserService>();

        // builder
        //     .Services.AddIdentityCore<User>()
        //     .AddEntityFrameworkStores<BookingAppContext>()
        //     .AddApiEndpoints();

        builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

        // For roles.
        builder.Services.AddAuthorization();

        var app = builder.Build();

        app.MapControllers();

        app.UseAuthentication();
        app.UseAuthorization();

        await CreateDefaultRoles(app);
        await CreateAdminAccount(app);

        app.Run();
    }



    static async Task CreateDefaultRoles(WebApplication app)
    {
        using var scope = app.Services.CreateAsyncScope();

        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        if (await roleManager.FindByNameAsync("Admin") == null)
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>("Admin"));
        }
        if (await roleManager.FindByNameAsync("User") == null)
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>("User"));
        }
    }

    static async Task CreateAdminAccount(WebApplication app)
    {
        using var scope = app.Services.CreateAsyncScope();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        if (await userManager.FindByNameAsync("Admin") == null)
        {
            var user = new User { UserName = "Admin" };
            var password = "Pass123!";
            var createUserResult = await userManager.CreateAsync(user, password);
            if (!createUserResult.Succeeded)
            {
                throw new Exception("Unable to create Admin user.");
            }
            var addRoleResult = await userManager.AddToRoleAsync(user, "Admin");
            if (!addRoleResult.Succeeded)
            {
                throw new Exception("Unable to assign role: 'Admin' to Admin user.");
            }
        }
    }
}
