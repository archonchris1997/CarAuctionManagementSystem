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
        Assert.Equal(vehicleRequest.Id, result.Data?.Id);
        Assert.Equal("Vehicle added", result.Message);
        Assert.NotNull(result.Data);
        
        //----------------------------------------------------------
        //Verify
        
        _mockVehicleRepository.Verify(repository => repository.Insert(It.Is<Vehicle>(v=>v.Id==10)), Times.Once);
        _mockCreateVehicleValidator.Verify(validator=> validator.Validate(vehicleRequest), Times.Once);
        
        
    }

    [Fact]
    public void AddVehicle_WhenIdAlreadyExists_ReturnsFailure_AndDoesNotInsert()
    {
         //Arrange
         
         var  vehicleRequest = new CreateVehicleRequest{
             Type = VehicleType.Suv,
             Id = 10,
             Manufacturer = "Toyota",
             Model = "RAV4",
             Year = 2021,
             StartingBid = 15000,
             NumberOfSeats = 5
         };

         _mockCreateVehicleValidator
             .Setup(validator => validator.Validate(vehicleRequest))
             .Returns(new List<string>());

         _mockVehicleRepository
             .Setup(r => r.GetById(10))
             .Returns(new SUV(
                 10,
                 VehicleType.Suv,
                 "Toyota",
                 "RAV4",
                 2021,
                 15000,
                 5
             ));
        

         //Act
         var result = _service.AddVehicle(vehicleRequest);
         
         //Assert
         
         Assert.False(result.Success);
         Assert.Equal("Vehicle already exists", result.Message);
         Assert.Contains("Id must be unique", result.Errors);
         
         //Verify
        _mockVehicleRepository.Verify(r => r.Insert(It.Is<Vehicle>(v=>v.Id==10)), Times.Never);
        _mockVehicleRepository.Verify(r => r.GetById(10), Times.Once);
        _mockCreateVehicleValidator.Verify(v=>v.Validate(vehicleRequest),Times.Once);
        
        
    }

    [Fact]
    public void GetModel_WhenModelExists_ReturnsVehicles()
    {
        //ARRANGE
        var modelo = "Corolla";
        
        var vehicles = new List<Vehicle>
        {
            new Sedan(1, VehicleType.Sedan, "Toyota", "Corolla", 2020, 1000, 4),
            new Sedan(2, VehicleType.Sedan, "Toyota", "Corolla", 2021, 1200, 4)
        };
        
        _mockVehicleRepository.Setup(r => r.GetByModel(modelo)).Returns(vehicles);
        
        //Act
        var result = _service.GetByModel(modelo);
        
        //Assert
        
        Assert.True(result.Success);
        Assert.Equal(2,result.Data?.Count());
        
        Assert.Equal(vehicles[0].Model, result?.Data?[0].Model);
        Assert.Equal(vehicles[1].Model, result?.Data?[1].Model);
        
        _mockVehicleRepository.Verify(r=>r.GetByModel(modelo),Times.Once);

    }

    [Fact]
    public void GetModel_WhenModelDoesNotExist()
    {
       // Arrange
       var modelo = "ClasseA";
       
       var vehicles = new List<Vehicle>
       {
           new Sedan(1, VehicleType.Sedan, "Toyota", "Corolla", 2020, 1000, 4),
           new Sedan(2, VehicleType.Sedan, "Toyota", "Corolla", 2021, 1200, 4)
       };
       
       _mockVehicleRepository.Setup(r=> r.GetByModel(modelo)).Returns(new List<Vehicle>());
       
       //Act
       var result = _service.GetByModel(modelo);
       
       //Assert 
       Assert.True(result.Success);
       Assert.NotNull(result.Data);
       Assert.Empty(result.Data);
       
       //Verify
       _mockVehicleRepository.Verify(r=>r.GetByModel(modelo),Times.Once);
       

    }

    [Fact]
    public void GetVehicle_WhenManufacturerExists()
    {
        //Arrange
        var manufactor = "Toyota";
        
        var vehicles = new List<Vehicle>
        {
            new Sedan(1, VehicleType.Sedan, "Toyota", "Corolla", 2020, 1000, 4),
            new Sedan(2, VehicleType.Sedan, "Toyota", "Corolla", 2021, 1200, 4)
        };
        
        _mockVehicleRepository.Setup(r=>r.GetByManufacturer(manufactor)).Returns(vehicles);
        
        //Act
        var result = _service.GetByManufacturer(manufactor);
        
        //Assert
        Assert.True(result.Success);
        Assert.Equal(2,result.Data?.Count());
        Assert.Equal(vehicles[0].Model, result?.Data?[0].Model);
        Assert.Equal(vehicles[1].Model, result?.Data?[1].Model);
        
        
        //Verify
        
        
    }
    
    /*
    [Fact]
    public void AddVehicle_WhenIdAlreadyExists_ReturnsFailure_AndDoesNotInsert()
    {
        // ------------------ Arrange
        var vehicleRequest = new CreateVehicleRequest
        {
            Type = VehicleType.Suv,
            Id = 10,
            Manufacturer = "Toyota",
            Model = "RAV4",
            Year = 2021,
            StartingBid = 15000,
            NumberOfSeats = 5
        };

        _mockCreateVehicleValidator
            .Setup(v => v.Validate(vehicleRequest))
            .Returns(new List<string>());

        // 👇 Forçar ID duplicado
        _mockVehicleRepository
            .Setup(r => r.GetById(10))
            .Returns(new SUV(
                10,
                VehicleType.Suv,
                "Toyota",
                "RAV4",
                2021,
                15000,
                5
            ));

        // ------------------ Act
        var result = _service.AddVehicle(vehicleRequest);

        // ------------------ Assert
        Assert.False(result.Success);
        Assert.Equal("Vehicle already exists", result.Message);
        Assert.Contains("Id must be unique", result.Errors);

        // ------------------ Verify
        _mockVehicleRepository.Verify(r => r.Insert(It.IsAny<Vehicle>()), Times.Never);
        _mockCreateVehicleValidator.Verify(v => v.Validate(vehicleRequest), Times.Once);
        _mockVehicleRepository.Verify(r => r.GetById(10), Times.Once);
    }
    
    
  */  
} 