using Microsoft.AspNetCore.Identity;

namespace BookingApplication.Models;

public class User : IdentityUser
{
    public string? Adress { get; set; }

    public ICollection<Booking> Bookings { get; set; } = [];
}
