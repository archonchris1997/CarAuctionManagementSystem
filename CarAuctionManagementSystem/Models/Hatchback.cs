namespace CarAuctionManagementSystem.Models;

public class Hatchback : Vehicle
{
    public Hatchback(int id, string manufacturer, string model, int year, double startingBid, int numberOfDoors)
        : base(id, VehicleType.Hatchback, manufacturer, model, year, startingBid)
    {
        NumberOfDoors = numberOfDoors; // usa a prop herdada (nullable)
    }
}
