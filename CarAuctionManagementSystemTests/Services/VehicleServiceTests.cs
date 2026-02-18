namespace CarAuctionManagementSystemTests.Services;
using System.Collections.Generic;
using CarAuctionManagementSystem.Dtos;
using CarAuctionManagementSystem.Models;
using CarAuctionManagementSystem.Repository;
using CarAuctionManagementSystem.Services;
using CarAuctionManagementSystem.Validation;
using Moq;
using Xunit;


public class VehicleServiceTests
{
    private readonly Mock<IVehicleRepository> _mockVehicleRepository;
    private readonly Mock<ICreateVehicleValidator> _mockCreateVehicleValidator;

    private readonly VehicleService _service;

    public VehicleServiceTests()
    {
        _mockVehicleRepository = new Mock<IVehicleRepository>();
        _mockCreateVehicleValidator = new Mock<ICreateVehicleValidator>();
        
        _service = new VehicleService(_mockVehicleRepository.Object, _mockCreateVehicleValidator.Object);
    }

    [Fact]
    public void AddVehicle_WhenValidReturnsSuccess_AndInsertsOnce()
    {
        //Arrange
        
        //Act
        
        //Assert
        
        //Verify
    }
    
    
    
}