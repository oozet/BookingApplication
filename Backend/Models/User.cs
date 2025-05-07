using Microsoft.AspNetCore.Identity;

namespace BookingApplication.Models;

public class AppUser : IdentityUser
{
    public ICollection<Booking> Bookings { get; set; } = [];
}