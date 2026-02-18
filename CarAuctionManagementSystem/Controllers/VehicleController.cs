using CarAuctionManagementSystem.Dtos;
using CarAuctionManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarAuctionManagementSystem.Controllers;

//Usar padrão automático (mais comum)

[ApiController]
[Route("api/controller")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateVehicleRequest request)
    {
        var result = _vehicleService.AddVehicle(request);

        if (result.Success)
        {
            return Ok(result);
        }
        
        return BadRequest(result);
    }

 
    [HttpGet("byManufacturer/{manufacturer}")]
    public IActionResult GetByManufacturer(string manufacturer)
    {
        var result = _vehicleService.GetByManufacturer(manufacturer);

        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpGet("byModel/{model}")]
    public IActionResult GetByModel(string model)
    {
        var result = _vehicleService.GetByModel(model);
        if (result.Success)
        {
            return Ok(result);
        }
        
        return BadRequest(result);
        
    }

    [HttpGet("byYear/{year}")]
    public IActionResult GetByYear(int year)
    {
        var result = _vehicleService.GetByYear(year);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    
    
/*
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _vehicleService.GetByModel()
    }
*/    
    


}