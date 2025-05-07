using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace BookingApplication.Models;

public class Activity
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<Booking> Bookings { get; set; } = [];
}