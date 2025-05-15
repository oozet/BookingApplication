namespace BookingApplication.Models.Dtos;

public class CreateBookingRequest : IRequest
{
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required Guid RoomId { get; set; }
    public required string UserId { get; set; }
    public Guid? ActivityId { get; set; }
}

public class EditBookingRequest : IRequest
{
    public required Guid Id { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required Guid RoomId { get; set; }
    public required string UserId { get; set; }
    public Guid? ActivityId { get; set; }
}