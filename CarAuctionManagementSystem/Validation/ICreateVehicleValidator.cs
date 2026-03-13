using CarAuctionManagementSystem.Dtos;

namespace CarAuctionManagementSystem.Validation;

public interface ICreateVehicleValidator
{
    List<string> Validate(CreateVehicleRequest request);

}