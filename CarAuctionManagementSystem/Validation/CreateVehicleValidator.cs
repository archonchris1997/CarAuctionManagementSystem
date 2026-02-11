using CarAuctionManagementSystem.Dtos;
using CarAuctionManagementSystem.Models;

namespace CarAuctionManagementSystem.Validation;

public class CreateVehicleValidator:ICreateVehicleValidator
{
    public List<string> Validate(CreateVehicleRequest request)
    {
        //Vamos validar o Request do Cliente
        var errors = new List<string>();

        if (request == null)
        {
            errors.Add("Vehicle cannot be null");
            return errors;
        }
        
        if (request.Id <= 0) errors.Add("Id must be greater than zero");
        if (string.IsNullOrWhiteSpace(request.Manufacturer)) errors.Add("Manufacturer is required");
        if (string.IsNullOrWhiteSpace(request.Model)) errors.Add("Model is required");
        if (request.Year <= 0) errors.Add("Year must be valid");
        if (request.StartingBid <= 0) errors.Add("StartingBid must be greater than zero");

        if (request.Type == VehicleType.Hatchback || request.Type == VehicleType.Sedan)
        {
            if (request.NumberOfDoors == null) errors.Add("NumberOfDoors is required");
        }
        else if (request.Type == VehicleType.Suv)
        {
            if (request.NumberOfSeats == null) errors.Add("NumberOfSeats is required");
        }
        else if (request.Type == VehicleType.Truck)
        {
            if (request.LoadCapacity == null) errors.Add("LoadCapacity is required");
        }

        return errors;
        
    }
}