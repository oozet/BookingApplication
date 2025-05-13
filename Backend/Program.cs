using BookingApplication.Data;
using BookingApplication.Models;
using BookingApplication.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookingApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<BookingAppContext>(options =>
            options.UseNpgsql(DbConfig.connectionString)
        );

        builder
            .Services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<BookingAppContext>()
            .AddDefaultTokenProviders();

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
        app.Run();
    }
}
