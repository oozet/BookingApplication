using BookingApplication.Interfaces;
using BookingApplication.Models;
using BookingApplication.Models.Dtos;

namespace BookingApplication.Services;

public class RoomService : EfService<Room, CreateRoomRequest, EditRoomRequest>
{
    public RoomService(IRepository<Room> repository) : base(repository) {}

    public override async Task<Room> CreateFromRequestAsync(CreateRoomRequest request)
    {
        if(string.IsNullOrWhiteSpace(request.Name))
        {
            throw new Exception("Room must have a name");
        }
        if(request.RoomNumber <= 0)
        {
            throw new Exception("Room number can't be 0 or negative");
        }
        if(request.Limit <= 0)
        {
            throw new Exception("Limit can't be less than 1");
        }
        if(request.Area <= 0)
        {
            throw new Exception("Area can't be less than 1");
        }
        if(request.Price < 0)
        {
            throw new Exception("Price can't be negative");
        }

        var room = new Room
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            RoomNumber = request.RoomNumber,
            Limit = request.Limit,
            Area = request.Area,
            Price = request.Price
        };

        await repository.CreateAsync(room);
        return room;
    }

    public override async Task<Room> EditFromRequestAsync(EditRoomRequest request)
    {
        if(request.Id == Guid.Empty)
        {
            throw new Exception("The activity ID can't be empty");
        }
        if(string.IsNullOrWhiteSpace(request.Name))
        {
            throw new Exception("Room must have a name");
        }
        if(request.RoomNumber <= 0)
        {
            throw new Exception("Room number can't be 0 or negative");
        }
        if(request.Limit <= 0)
        {
            throw new Exception("Limit can't be less than 1");
        }
        if(request.Area <= 0)
        {
            throw new Exception("Area can't be less than 1");
        }
        if(request.Price < 0)
        {
            throw new Exception("Price can't be negative");
        }
        if(request.Bookings == null)
        {
            throw new Exception("The collection of bookings can't be null");
        }

        var room = new Room 
        {
            Id = request.Id,
            Name = request.Name,
            RoomNumber = request.RoomNumber,
            Limit = request.Limit,
            Area = request.Area,
            Price = request.Price,
            Bookings = request.Bookings
        };

        await repository.EditAsync(room);
        return room;
    }
}