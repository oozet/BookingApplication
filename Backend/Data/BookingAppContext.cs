using BookingApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookingApplication.Data;

public class BookingAppContext(DbContextOptions<BookingAppContext> options) : IdentityDbContext(options)
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Privileges> Privileges { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Activity> Activities { get; set; }
}
