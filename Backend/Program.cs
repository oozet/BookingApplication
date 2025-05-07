using BookingApplication.Data;
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
            .Services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<BookingAppContext>()
            .AddDefaultTokenProviders();

        builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddControllers();

        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}
