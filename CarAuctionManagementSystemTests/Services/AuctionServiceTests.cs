using CarAuctionManagementSystem.Dtos;
using CarAuctionManagementSystem.Repository;
using CarAuctionManagementSystem.Services;
using Moq;

namespace CarAuctionManagementSystemTests.Services;

public class AuctionServiceTests
{
    
    private readonly Mock<IAuctionRepository> _mockAuctionRepository;
    private readonly Mock<IVehicleRepository> _mockVehicleRepository;
    
    private readonly AuctionService _service;
    
    public AuctionServiceTests()
    {
        _mockAuctionRepository = new Mock<IAuctionRepository>();
        _mockVehicleRepository = new Mock<IVehicleRepository>();
        
        _service = new AuctionService(_mockAuctionRepository.Object, _mockVehicleRepository.Object);
    }
    
    // Testar que a Start Auction correu bem
    [Fact]
    public void StartAuction_WhenValidReturnsSuccess_AndStartAuctionOnce()
    {
        //Arrange
        
    }
    
    
    
    
}