namespace CarAuctionManagementSystem.Models;

public class Sedan:Vehicle
{
    int NumberOfDoors;

    protected Sedan(int id, VehicleType type, string manufacturer, string model, int year, double startingBid, int numberOfDoors) : base(id, type, manufacturer, model, year, startingBid)
    {
        this.NumberOfDoors = numberOfDoors;
    }
}