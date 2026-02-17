using CarAuctionManagementSystem.Dtos;
using CarAuctionManagementSystem.Utils;

namespace CarAuctionManagementSystem.Services;

public interface IAuctionService
{
    OperationResult<AuctionDto> StartAuction(int vehicleId);
    OperationResult<AuctionDto> CloseAuction(int vehicleId);
    OperationResult<AuctionDto> PlaceBid(int vehicleId, double bid);
}