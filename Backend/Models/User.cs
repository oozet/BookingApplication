using Microsoft.AspNetCore.Identity;

namespace BookingApplication.Models;

public class User : IdentityUser
{
    public ICollection<Booking> Bookings { get; set; } = [];
}