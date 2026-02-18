using System.Net.Security;
using CarAuctionManagementSystem.Dtos;
using CarAuctionManagementSystem.Mappers;
using CarAuctionManagementSystem.Models;
using CarAuctionManagementSystem.Repository;
using CarAuctionManagementSystem.Utils;
using CarAuctionManagementSystem.Validation;

namespace CarAuctionManagementSystem.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _repository;
    private readonly ICreateVehicleValidator  _validator;
    
    public VehicleService(IVehicleRepository repo, ICreateVehicleValidator validator)
    {
        _repository = repo;
        _validator = validator;
    }
    
    public OperationResult<VehicleDto> AddVehicle(CreateVehicleRequest request)
    {
        //Validar request
        var erros = _validator.Validate(request);

        if (erros.Count > 0)
        {
            return new OperationResult<VehicleDto>()
            {
                Success = false,
                Message = "Validation failed",
                Errors = erros,
                Data = null
            };
        }
        
        // Criar veículo 
        Vehicle vehicle = CreateVehicle(request);
        
        // Verificar ID duplicado
        if (_repository.GetById(vehicle.Id) != null)
        {
            return new OperationResult<VehicleDto>()
            {
                Success = false,
                Message = "Vehicle already exists",
                Errors = new List<string> { "Id must be unique" },
                Data = null
            };
        }
        
        _repository.Insert(vehicle);
        
        
        return new OperationResult<VehicleDto>()
        {

            Success = true,
            Message = "Vehicle added",
            // Retornar para o Controller em DTO
            
            //1 Veículo *apenas*
            Data = VehicleMapper.ToDto(vehicle)
        };
        
        
    }

    public OperationResult<List<VehicleDto>> GetAll()
    {
        var vehicles = _repository.GetAll();
        
        
        //Mandar para o Controller em DTO's
        var dtos = new List<VehicleDto>();
        
        foreach (var vehicle in vehicles)
        {
            var vehicleMapped = VehicleMapper.ToDto(vehicle);
            dtos.Add(vehicleMapped);
        }
        
        return new OperationResult<List<VehicleDto>>()
        {
            Success = true,
            Message = "Ok",
            Data = dtos
        };
    }

    public OperationResult<List<VehicleDto>> GetByManufacturer(string manufacturer)
    {
        var vehicles=_repository.GetByManufacturer(manufacturer);
        
        //Agora preciso de converter os veiculos para Dtos
        var dtos = new List<VehicleDto>();
        foreach (var vehicle in vehicles)
        {
            var dto = VehicleMapper.ToDto(vehicle);
            dtos.Add(dto);
        }

        return new OperationResult<List<VehicleDto>>
        {
            Success = true,
            Message = "Ok",
            Data = dtos
        };
        
    }

    public OperationResult<List<VehicleDto>> GetByModel(string model)
    {
        var vehicles=_repository.GetByModel(model);
        
        //Converter para dtos 
        var dtos = new List<VehicleDto>();
        
        foreach (var vehicle in vehicles)
        {
            var dto = VehicleMapper.ToDto(vehicle);
            dtos.Add(dto);
        }

        return new OperationResult<List<VehicleDto>>()
        {
            Success = true,
            Message = "Ok",
            Data = dtos
        };
    }

    public OperationResult<List<VehicleDto>> GetByYear(int year)
    {
        
        var vehicles=_repository.GetByYear(year);
        var dtos = new List<VehicleDto>();
        foreach (var vehicle in vehicles)
        {
            var dto = VehicleMapper.ToDto(vehicle);
            dtos.Add(dto);
        }

        return new OperationResult<List<VehicleDto>>()
        {
            Success = true,
            Message = "Ok",
            Data = dtos
        };
    }

    private Vehicle CreateVehicle(CreateVehicleRequest request)
    {

        switch (request.Type)
        {
            case VehicleType.Hatchback:
                return new Hatchback(
                    request.Id,
                    request.Manufacturer,
                    request.Model,
                    request.Year,
                    request.StartingBid,
                    request.NumberOfDoors!.Value
                );

            case VehicleType.Sedan:
                return new Sedan(
                    request.Id,
                    VehicleType.Sedan, // 👈 ESTE é o que falta
                    request.Manufacturer,
                    request.Model,
                    request.Year,
                    request.StartingBid,
                    request.NumberOfDoors!.Value
                );


            case VehicleType.Suv:
                return new SUV(
                    request.Id,
                    VehicleType.Suv, // 👈 está a faltar isto
                    request.Manufacturer,
                    request.Model,
                    request.Year,
                    request.StartingBid,
                    request.NumberOfSeats!.Value
                );


            case VehicleType.Truck:
                return new Truck(
                    request.Id,
                    VehicleType.Truck, // 👈 ESTE estava a faltar
                    request.Manufacturer,
                    request.Model,
                    request.Year,
                    request.StartingBid,
                    request.LoadCapacity!.Value
                );


            default:
                throw new ArgumentException("Unsupported vehicle type");
        }

    }
}