using CarAuctionManagementSystem.Models;
using CarAuctionManagementSystem.Services;
using CarAuctionManagementSystem.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CarAuctionManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuctionController:ControllerBase
{
    private readonly IAuctionService _auctionService;
   
    public AuctionController(IAuctionService auctionService)
    {
        _auctionService = auctionService;
    }

    
    [HttpPost("start/{vehicleId}")]
    public IActionResult StartAuction(int vehicleId)
    {
        var result = _auctionService.StartAuction(vehicleId);
        
        //return Ok(result);
        return ToHttp(result);
    }

    [HttpPost("close/{vehicleId}")]
    public IActionResult CloseAuction(int vehicleId)
    {
        var result = _auctionService.CloseAuction(vehicleId);
        return ToHttp(result);
        
    }

    public IActionResult PlaceBid(int vehicleId, int bid)
    {
        var result = _auctionService.PlaceBid(vehicleId, bid);
        return ToHttp(result);
    }

    private IActionResult ToHttp<T>(OperationResult<T> result)
    {
        if(result.Success){
            return Ok(result.Data);
        }

        switch (result.ErrorType)
        {
            case ErrorType.Validation:
                return BadRequest(result);

            case ErrorType.NotFound:
                return NotFound(result);

            case ErrorType.Conflict:
                return Conflict(result);

            default:
                return StatusCode(500, result);
        }

        
    }
    
}