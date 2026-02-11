namespace CarAuctionManagementSystem.Dtos;

public class VehicleDto
{
    public int Id { get; set; }
    public string Type { get; set; } = "";

    public string Manufacturer { get; set; } = "";
    public string Model { get; set; } = "";
    public int Year { get; set; }
    public double StartingBid { get; set; }

    public int? NumberOfDoors { get; set; }
    public int? NumberOfSeats { get; set; }
    public int? LoadCapacity { get; set; }
}