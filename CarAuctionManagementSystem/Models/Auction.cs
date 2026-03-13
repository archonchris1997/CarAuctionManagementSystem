using CarAuctionManagementSystem.Utils;

namespace CarAuctionManagementSystem.Models;

public class Auction
{
    public int Id { get; set; }
    public bool Active { get; set; }
    public Vehicle Vehicle { get; set; }
    public double Bid { get; set; }

    public Auction(Vehicle vehicle)
    {
        Id = IDGenerator.GetNextAuctionId();
        Vehicle = vehicle;
        Bid=vehicle.StartingBid;
        Active = false;
    }
}