using CarAuctionManagementSystem.Models;

namespace CarAuctionManagementSystem.Repository;

public class AuctionRepository:IAuctionRepository
{
    
    private readonly Dictionary<int,Auction> _auctions = new Dictionary<int, Auction>();

    public IEnumerable<Auction> GetAll()
    {
        return _auctions.Values;
    }

    public Auction? GetByVehicleId(int vehicleId)
    {
        if (_auctions.ContainsKey(vehicleId))
            return _auctions[vehicleId];

        return null;
    }

    public Auction? GetById(int auctionId)
    {

        if (_auctions.TryGetValue(auctionId, out var auction))
        {
            return auction;
            
        }
        return null;
    }

    public void Insert(Auction auction)
    {
        _auctions.Add(auction.Vehicle.Id, auction);
    }

    public void Update(Auction auction)
    {
        _auctions[auction.Vehicle.Id] = auction;
    }
}