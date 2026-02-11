using CarAuctionManagementSystem.Dtos;
using CarAuctionManagementSystem.Models;

namespace CarAuctionManagementSystem.Mappers;

public class VehicleMapper
{
    public static VehicleDto ToDto(Vehicle vehicle)
    {
        var dto = new VehicleDto();
        
        dto.Id = vehicle.Id;
        dto.Type = vehicle.Type.ToString();
        dto.Manufacturer = vehicle.Manufacturer;
        dto.Model = vehicle.Model;
        dto.Year = vehicle.Year;
        dto.StartingBid = vehicle.StartingBid;

        if (vehicle is Hatchback hatchback)
        {
            dto.NumberOfDoors = hatchback.NumberOfDoors;
        }
        else if (vehicle is Sedan sedan)
        {
            dto.NumberOfDoors = sedan.NumberOfDoors;
        }
        else if (vehicle is SUV suv)
        {
            dto.NumberOfSeats =suv.NumberOfSeats;
        }
        else if (vehicle is Truck truck)
        {
            dto.LoadCapacity = truck.LoadCapacity;
        }

        return dto;
    }
}