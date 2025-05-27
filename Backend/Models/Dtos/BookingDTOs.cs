namespace BookingApplication.Models.Dtos;

public class CreateBookingRequest : IRequest
{
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required Guid RoomId { get; set; }
    public required Guid UserId { get; set; }
    public Guid? ActivityId { get; set; }
}

public class EditBookingRequest : IRequest
{
    public required Guid Id { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required Guid RoomId { get; set; }
    public required Guid UserId { get; set; }
    public Guid? ActivityId { get; set; }
}

public class BookingResponse
{
    public required Guid Id { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required Guid RoomId { get; set; }
    public required Guid UserId { get; set; }
    public Guid? ActivityId { get; set; }

    public static BookingResponse FromModel(Booking booking)
    {
        return new BookingResponse
        {
            Id = booking.Id,
            StartDate = booking.StartDate,
            EndDate = booking.EndDate,
            RoomId = booking.RoomId,
            UserId = booking.UserId,
            ActivityId = booking.ActivityId
        };
    }
}