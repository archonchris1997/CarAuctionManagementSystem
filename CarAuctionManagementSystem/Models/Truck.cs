namespace CarAuctionManagementSystem.Models;

public class Truck : Vehicle
{
    public int LoadCapacity { get; set; }

    public Truck(
        int id,
        VehicleType type,
        string manufacturer,
        string model,
        int year,
        double startingBid,
        int loadCapacity)
        : base(id, type, manufacturer, model, year, startingBid)
    {
        LoadCapacity = loadCapacity;
    }
}

