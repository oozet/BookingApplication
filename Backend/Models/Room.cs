namespace BookingApplication.Models;

public class Room
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int RoomNumber { get; set; }
    public int Limit { get; set; }
    public int Area { get; set; }
    public double Price { get; set; }

    public Room(string name, int roomNumber, int limit, int area, double price)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        RoomNumber = roomNumber;
        Limit = limit;
        Area = area;
        Price = price;
    }

    private Room() { }

}

// public class RoomEntity
// {
//     public required string Id { get; set; } = null!;
//     public required string Name { get; set; } = null!;
//     public required int RoomNumber { get; set; }
//     public required int Limit { get; set; }
//     public required int Area { get; set; }
//     public required double Price { get; set; }
// }