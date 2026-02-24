using CarAuctionManagementSystem.Models;

namespace CarAuctionManagementSystem.Repository;

public class AuctionRepository:IAuctionRepository
{
    
    //Básicamente vai a Key vai ser o VeículoID e a Auction vai ser o Value
    private readonly Dictionary< int, Auction> _auctions = new Dictionary<int, Auction>();

    public IEnumerable<Auction> GetAll()
    {
        return _auctions.Values;
    }

    public Auction? GetAuctionByVehicleId(int vehicleId)
    {
        if (_auctions.ContainsKey(vehicleId))
            
            return _auctions[vehicleId];

        return null;
    }

    public Auction? GetById(int auctionId)
    {
        /*
        if (_auctions.TryGetValue(auctionId, out var auction))
        {
            return auction;
            
        }*/

        if (_auctions.ContainsKey(auctionId))
        {
            return _auctions[auctionId];
        }
        
        return null;
    }

    public void Insert(Auction auction)
    {
        _auctions.Add(auction.Vehicle.Id, auction);
    }

    public void Update(Auction auction)
    {
        
        int key = auction.Vehicle.Id;
        if (_auctions.ContainsKey(key))
        {
            _auctions[key] = auction;
        }
        
    }
}