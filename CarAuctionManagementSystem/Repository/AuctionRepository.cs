using CarAuctionManagementSystem.Models;

namespace CarAuctionManagementSystem.Repository;

public class AuctionRepository:IAuctionRepository
{
    
    private readonly Dictionary<int,Auction> _auctions = new Dictionary<int, Auction>();

    public IEnumerable<Auction> GetAll()
    {
        return _auctions.Values;
    }

    public Auction? GetByVehicleId(int id)
    {
        if (_auctions.TryGetValue(id, out var vehicle))
        {
            return vehicle;
        }

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
        throw new NotImplementedException();
    }

    public void Update(Auction auction)
    {
        throw new NotImplementedException();
    }
}