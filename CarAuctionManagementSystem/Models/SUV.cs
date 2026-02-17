namespace CarAuctionManagementSystem.Models;

public class SUV : Vehicle
{
    public SUV(
        int id,
        VehicleType type,
        string manufacturer,
        string model,
        int year,
        double startingBid,
        int numberOfSeats)
        : base(id, type, manufacturer, model, year, startingBid)
    {
        NumberOfSeats = numberOfSeats; // usa a propriedade herdada
    }
}

