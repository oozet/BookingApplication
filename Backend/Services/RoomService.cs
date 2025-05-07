using Backend_ind.Services;
using BookingApplication.Controllers;
using BookingApplication.Data;
using BookingApplication.Interfaces;
using BookingApplication.Models;
using BookingApplication.Repositories;

public class RoomService : EfService<Room, CreateRoomRequest, EditRoomRequest>
{
    public RoomService(IRepository<Room> repository) : base(repository) {}

    public override Task<Room> CreateFromRequestAsync(CreateRoomRequest request)
    {
        throw new NotImplementedException();
    }

    public override Task<Room> EditFromRequestAsync(EditRoomRequest request)
    {
        throw new NotImplementedException();
    }
}