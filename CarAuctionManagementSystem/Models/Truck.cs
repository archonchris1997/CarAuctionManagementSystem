namespace CarAuctionManagementSystem.Models;

public class Truck:Vehicle
{
    protected Truck(int id, VehicleType type, string manufacturer, string model, int year, double startingBid, int loadCapacity) : base(id, type, manufacturer, model, year, startingBid)
    {
        LoadCapacity = loadCapacity;
    }

    public int LoadCapacity { get; set; }
    
    
}