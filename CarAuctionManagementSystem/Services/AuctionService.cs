using CarAuctionManagementSystem.Dtos;
using CarAuctionManagementSystem.Mappers;
using CarAuctionManagementSystem.Models;
using CarAuctionManagementSystem.Repository;
using CarAuctionManagementSystem.Utils;

namespace CarAuctionManagementSystem.Services;

public class AuctionService:IAuctionService
{
    private readonly IAuctionRepository _auctionRepository;
    private readonly IVehicleRepository _vehicleRepository;

    public AuctionService(IAuctionRepository auctionRepository, IVehicleRepository vehicleRepository)
    {
        _auctionRepository = auctionRepository;
        _vehicleRepository = vehicleRepository; 
    }
    public OperationResult<AuctionDto> StartAuction(int vehicleId)
    {
        // vou ver se o veículo existe
            // se o veículo não existir então saio 

            var vehicle = _vehicleRepository?.GetById(vehicleId);

            if (vehicle == null)
            {
                return new OperationResult<AuctionDto>()
                {
                    Success = false,
                    Message = "Vehicle does not exist",
                    Errors = new List<string>
                    {
                        "Vehicle not found."
                    },
                    Data = null
                };
            }
            
            // Verificar se a Auction
            // Se já existir então não faz sentido a criar novamente
                
                // => Basicamente vai verificar pelo id do veículo se exite alguma Auction associada ao veículo
        
                
                // 2) Check auction already exists for this vehicle
                var existingAuction = _auctionRepository?.GetAuctionByVehicleId(vehicleId);
                
                if (existingAuction != null)
                {
                    return new OperationResult<AuctionDto>
                    {
                        Success = false,
                        Message = "Vehicle already has an auction",
                        Errors = new List<string>()
                        {
                            "Vehicle already has an auction."
                        },
                        Data = null
                    };
                } 
        
            // se o veículo existir e se a Auction não existir
            // Então vou Inserir uma nova Auction com esse veículo 
           Auction auction = new Auction(vehicle);
           
           auction.Active = true;
          
           
            _auctionRepository?.Insert(auction);

            var dtoAuction = Mappers.AuctionMapper.ConvertToDto(auction);
            
            return new OperationResult<AuctionDto>()
            {

                Success = true,
                Errors = new List<string>(),
                Message = "Auction started",
                Data = dtoAuction
            };
    }
    
    public OperationResult<AuctionDto> PlaceBid(int vehicleId, double bid)
    {
        // Basicamente aqui é só meter uma Bid 
        
        // Vou ter de fazer as verificações habituais 
        
        /*  
         * 1º verificar se o veículo existe
         * 2º verificar se a auction existe
         * 3º verificar se a bid > bidAtual
         */

        if (_vehicleRepository.GetById(vehicleId) == null)
        {
            return new OperationResult<AuctionDto>()
            {
                Success = false,
                Message = "Vehicle does not exist",
                Data = null,
                Errors = new List<string>()
                {
                    "Vehicle not found."
                }
                
            };
        }

        if (_auctionRepository.GetAuctionByVehicleId(vehicleId) == null)
        {
            return new OperationResult<AuctionDto>()
            {
                Success = false,
                Message = "Auction does not exist",
                Data = null,
                Errors = new List<string>()
                {
                    "Auction not found."
                }
            };
        }

        var auction = _auctionRepository.GetAuctionByVehicleId(vehicleId);

        if ( auction.Bid > bid )
        {
            return new OperationResult<AuctionDto>()
            {
                Success = false,
                Message = "Bid is too big",
                Data = null,
                Errors = new List<string>()
                {
                    "Bid is too big"
                }
            };
            
        }

        auction.Bid = bid;
        
        _auctionRepository?.Update(auction);
        
        return new OperationResult<AuctionDto>()
        {
            Success = true,
            Data = AuctionMapper.ConvertToDto(auction),
            Errors = new List<string>(),
            Message = "Auction placed",
        };
        
    }
    
    public OperationResult<AuctionDto> CloseAuction(int vehicleId)
    {
        /*
         1º - verificar se o veículo existe
         2º - Verificar se a Auction existe
         3º - Verificar se a Auction está fechada
         4º - Fechar a Auction 
         */
        
        var vehicle = _vehicleRepository.GetById(vehicleId);
        
        if (vehicle == null)
        {
            return new OperationResult<AuctionDto>()
            {
                Success = false,
                Message = "Vehicle does not exist",
                Data = null,
                Errors = new List<string>()
                {
                    "Vehicle not found"
                }
            };
        }
        
        var auction = _auctionRepository.GetAuctionByVehicleId(vehicleId);

        if (auction == null)
        {
            return new OperationResult<AuctionDto>()
            {
                Success = false,
                Message = "Auction does not exist",
                Data = null,
                Errors = new List<string>()
                {
                    "Auction not found"
                }
            };
        }
        
        if (auction.Active == false)
        {
            return new OperationResult<AuctionDto>()
            {
                Success = false,
                Message = "Auction is already closed",
                Data = null,
                Errors = new List<string>()
                {
                    "Auction is already closed"
                }
            };
        }
        
        auction.Active = false;
        
        _auctionRepository?.Update(auction);

        return new OperationResult<AuctionDto>()
        {
            Success = true,
            Data = AuctionMapper.ConvertToDto(auction),
            Message = "Auction closed",
            Errors = new List<string>()
            
        };
        
    }

    
}