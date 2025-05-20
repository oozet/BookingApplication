using Microsoft.AspNetCore.Identity;

namespace BookingApplication.Models;

public class User : IdentityUser<Guid>
{
    public string? Adress { get; set; }

    public ICollection<Booking> Bookings { get; set; } = [];
}
