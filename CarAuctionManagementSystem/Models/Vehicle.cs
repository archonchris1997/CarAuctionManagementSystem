namespace CarAuctionManagementSystem.Models;

public class Vehicle
{
    public int Id { get; set; }
    public VehicleType Type { get; set; }
    
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public int Year { get; set; }
    public double StartingBid { get; set; }
    
    // Optional depending on Type
    public int? NumberOfDoors { get; set; }   // Hatchback/Sedan
    public int? NumberOfSeats { get; set; }   // Suv
    public int? LoadCapacity { get; set; }    // Truck
    
    
}