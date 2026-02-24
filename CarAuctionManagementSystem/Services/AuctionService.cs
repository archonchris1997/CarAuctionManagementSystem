using CarAuctionManagementSystem.Dtos;
using CarAuctionManagementSystem.Repository;
using CarAuctionManagementSystem.Utils;

namespace CarAuctionManagementSystem.Services;

public class AuctionService:IAuctionService
{
    private readonly IAuctionRepository? _auctionRepository;
    private readonly IVehicleRepository? _vehicleRepository;
    
    
    public OperationResult<AuctionDto> StartAuction(int vehicleId)
    {
        // vou ver se o veículo existe
            // se o veículo não existir então saio 

            var result = _vehicleRepository?.GetById(vehicleId);

            if (result == null)
            {
                return new OperationResult<AuctionDto>()
                {
                    Success = false,
                    Message = "Vehicle not found",
                    Errors = new List<string>(),
                    Data = null
                };
            }
            
            // Verificar se a Auction
            // Se já existir então não faz sentido a criar novamente
                
                // => Basicamente vai verificar pelo id do veículo se exite alguma Auction associada ao veículo

                if (_auctionRepository?.GetAuctionByVehicleId(vehicleId) != null)
                {
                    return new OperationResult<AuctionDto>()
                    {
                        Success = false,
                        Message = "Vehicle already has Auction",
                        Errors = new List<string>(),
                        Data = null
                    };

                }    
            

            // se o veículo existir e se a Auction não existir
            // Então vou Inserir uma nova Auction com esse veículo 



    }

    public OperationResult<AuctionDto> CloseAuction(int vehicleId)
    {
        throw new NotImplementedException();
    }

    public OperationResult<AuctionDto> PlaceBid(int vehicleId, double bid)
    {
        throw new NotImplementedException();
    }
}