namespace CarAuctionManagementSystem.Models;

public class Sedan : Vehicle
{
    public Sedan(
        int id,
        VehicleType type,
        string manufacturer,
        string model,
        int year,
        double startingBid,
        int numberOfDoors)
        : base(id, type, manufacturer, model, year, startingBid)
    {
        NumberOfDoors = numberOfDoors; // usa a propriedade herdada
    }
}
