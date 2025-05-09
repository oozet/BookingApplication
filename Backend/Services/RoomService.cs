using BookingApplication.Controllers;
using BookingApplication.Data;
using BookingApplication.Interfaces;
using BookingApplication.Models;
using BookingApplication.Repositories;

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
            Id = new Guid(), // ?
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

        /*
        Should we find the entity and edit that or create a new one? If we find it bookings doesn't need to be in the request
        If so theres no need to have "EditAsync" in the repositories since we can just save the changes here
        try{ 
            var room = await GetByIdAsync(request.Id); 
            room.Name = request.Name;
            room.Description = request.Description;
            await repository.SaveChangesAsync();
            return activity;
        }
        catch (Exeption)
        {
            throw;
        }

        */

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