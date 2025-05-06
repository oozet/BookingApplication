namespace BookingApplication.Models;

public class RoomEntity
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int RoomNumber { get; set; }
    public int Limit { get; set; }
    public int Area { get; set; }
    public double Price { get; set; }

    public RoomEntity(string name, int roomNumber, int limit, int area, double price)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        RoomNumber = roomNumber;
        Limit = limit;
        Area = area;
        Price = price;
    }

    private RoomEntity() { }

}