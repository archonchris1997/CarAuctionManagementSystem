namespace CarAuctionManagementSystem.Dtos;

public class AuctionDto
{
    public int AuctionId { get; set; }
    public int VehicleId { get; set; }
    public bool Active { get; set; }
    public double CurrentBid { get; set; }
    public double StartingBid { get; set; }
}