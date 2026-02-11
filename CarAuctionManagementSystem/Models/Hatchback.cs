namespace CarAuctionManagementSystem.Models;

public class Hatchback:Vehicle
{
    public int NumberOfDoors { get; set; }
    
    
    
// protected Vehicle(int id, VehicleType type, string manufacturer, string model, int year, double startingBid)

    public Hatchback(int id, string manufacturer, string model, int year, double startingBid, int numberOfDoors)
        : base(id, VehicleType.Hatchback, manufacturer, model, year, startingBid)
    {
        NumberOfDoors = numberOfDoors;
    }
    
    
    
    
    
    
}