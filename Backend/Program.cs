using BookingApplication.Data;
using BookingApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookingApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<BookingAppContext>(options => options.UseNpgsql(DbConfig.connectionString));

        builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

        builder.Services.AddIdentityCore<User>()
         .AddEntityFrameworkStores<BookingAppContext>()
         .AddApiEndpoints();

        builder.Services.AddControllers();

        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}