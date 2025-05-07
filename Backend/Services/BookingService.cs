using Backend_ind.Services;
using BookingApplication.Controllers;
using BookingApplication.Data;
using BookingApplication.Interfaces;
using BookingApplication.Models;
using BookingApplication.Repositories;

public class BookingService : EfService<Booking, CreateBookingRequest,EditBookingRequest>
{
    public BookingService(IRepository<Booking> repository) : base(repository) {}

    public override Task<Booking> CreateFromRequestAsync(CreateBookingRequest request)
    {
        throw new NotImplementedException();
    }

    public override Task<Booking> EditFromRequestAsync(EditBookingRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<List<Booking>> GetByTimeSpanAsync(DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }
}