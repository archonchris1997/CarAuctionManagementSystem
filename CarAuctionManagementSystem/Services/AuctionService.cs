using CarAuctionManagementSystem.Dtos;
using CarAuctionManagementSystem.Repository;
using CarAuctionManagementSystem.Utils;

namespace CarAuctionManagementSystem.Services;

public class AuctionService:IAuctionService
{
    private readonly IAuctionRepository _auctionRepository;
    private readonly IVehicleRepository _vehicleRepository;
    
    
    public OperationResult<AuctionDto> StartAuction(int vehicleId)
    {
        throw new NotImplementedException();
    }

    public OperationResult<AuctionDto> CloseAuction(int vehicleId)
    {
        throw new NotImplementedException();
    }

    public OperationResult<AuctionDto> PlaceBid(int vehicleId, double bid)
    {
        throw new NotImplementedException();
    }
}