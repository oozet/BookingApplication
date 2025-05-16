using BookingApplication.Models;
namespace BookingApplication.Models.Dtos;

public class CreateRoomRequest : IRequest
{
    public required string Name { get; set; }
    public required int RoomNumber { get; set; }
    public required int Limit { get; set; }
    public required int Area { get; set; }
    public required double Price { get; set; }
}

public class EditRoomRequest : IRequest
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required int RoomNumber { get; set; }
    public required int Limit { get; set; }
    public required int Area { get; set; }
    public required double Price { get; set; }
    public required ICollection<Booking> Bookings { get; set; }
}