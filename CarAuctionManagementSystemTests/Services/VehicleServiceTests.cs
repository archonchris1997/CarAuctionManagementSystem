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
        //----------------------------- Arrange
        
        // preparar o objeto que vou enviar para o Insert do Repositório
        
        var  vehicleRequest = new CreateVehicleRequest{
            Type = VehicleType.Suv,
            Id = 10,
            Manufacturer = "Toyota",
            Model = "RAV4",
            Year = 2021,
            StartingBid = 15000,
            NumberOfSeats = 5
        };

        _mockCreateVehicleValidator.
            Setup(v => v.Validate(vehicleRequest))
            .Returns(new List<string>());
        
    
        
        //Forçar o sucesso nos ifs para isolar o serviço
        _mockVehicleRepository
            .Setup(r => r.GetById(10))
            .Returns((Vehicle?)null);
        //----------------------------------------------------------
        //Act
        var result = _service.AddVehicle(vehicleRequest);
        
        //----------------------------------------------------------
        //Assert

        Assert.True(result.Success);
        Assert.Equal(vehicleRequest.Id, result.Data.Id);
        Assert.Equal("Vehicle created", result.Message);
        
        //----------------------------------------------------------
        //Verify
        
        _mockVehicleRepository.Verify(repository => repository.Insert(It.Is<Vehicle>(v=>v.Id==10)), Times.Once);
        _mockCreateVehicleValidator.Verify(validator=> validator.Validate(vehicleRequest), Times.Once);
        
        
        
    }
    
    
    
}