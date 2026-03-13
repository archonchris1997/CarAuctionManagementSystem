namespace CarAuctionManagementSystem.Utils;

//Used for Shared Utilities
public static class IDGenerator
{
    private static int _currentAuctionId = 0;

    public static int GetNextAuctionId()
        => Interlocked.Increment(ref _currentAuctionId);
    
}