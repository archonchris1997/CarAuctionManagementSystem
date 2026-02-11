using CarAuctionManagementSystem.Dtos;
using CarAuctionManagementSystem.Models;

namespace CarAuctionManagementSystem.Mappers;

public class AuctionMapper
{
    public static AuctionDto ToDto(Auction auction)
    {
        var dto = new AuctionDto();
        
        dto.AuctionId = auction.Id;
        dto.VehicleId = auction.Vehicle.Id;
        dto.Active = auction.Active;
        dto.CurrentBid = auction.Bid;
        dto.StartingBid = auction.Vehicle.StartingBid;
        
        return dto;
        
    }
    
}