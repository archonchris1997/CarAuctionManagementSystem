using CarAuctionManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarAuctionManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuctionController:ControllerBase
{
    private readonly IAuctionService _auctionService;
   
    
    
    
}