using BookingApplication.Controllers;
using BookingApplication.Data;
using BookingApplication.Interfaces;
using BookingApplication.Models;
using BookingApplication.Repositories;

namespace BookingApplication.Services;

public class BookingService : EfService<Booking, CreateBookingRequest, EditBookingRequest>
{
    public BookingService(BookingRepository repository) : base(repository) {}

    public override async Task<Booking> CreateFromRequestAsync(CreateBookingRequest request)
    {
        if(request.StartDate < DateTime.Now || request.EndDate < DateTime.Now)
        {
            throw new Exception("Booking dates can't be in the past");
        }
        if(request.RoomId == Guid.Empty)
        {
            throw new Exception("A room must be linked to the booking");
        }
        if(string.IsNullOrWhiteSpace(request.UserId))
        {
            throw new Exception("A user must be linked to the booking");
        }
        if(request.Price < 0)
        {
            throw new Exception("Price can't be negative");
        }

        var booking = new Booking
        {
            Id = Guid.NewGuid(),
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Price = request.Price,
            RoomId = request.RoomId,
            UserId = request.UserId,
            ActivityId = request.ActivityId,
        };

        await repository.CreateAsync(booking);
        return booking;
    }

    public override async Task<Booking> EditFromRequestAsync(EditBookingRequest request)
    {
        if(request.StartDate < DateTime.Now || request.EndDate < DateTime.Now)
        {
            throw new Exception("Booking dates can't be in the past");
        }
        if(request.Price < 0)
        {
            throw new Exception("Price can't be negative");
        }

        var booking = new Booking
        {
            Id = request.Id,
            RoomId = request.RoomId,
            UserId = request.UserId.ToString(),
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Price = request.Price,
            ActivityId = request.ActivityId
        };

        await repository.EditAsync(booking);
        return booking;
    }

    /*public async Task<List<Booking>> GetByTimeSpanAsync(DateTime start, DateTime end)
    {
        return (List<Booking>)await ((BookingRepository)repository).GetByTimeSpanAsync(start, end);
    }*/
}