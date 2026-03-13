using CarAuctionManagementSystem.Models;

namespace CarAuctionManagementSystem.Repository;

public interface IVehicleRepository
{
    Vehicle?  GetById(int id);
    
    IEnumerable<Vehicle> GetAll();
    IEnumerable<Vehicle> GetByType(VehicleType vehicleType);
    IEnumerable<Vehicle> GetByManufacturer(string manufacturer);
    
    IEnumerable<Vehicle> GetByModel(string model);
    IEnumerable<Vehicle> GetByYear(int year);
    
    void Insert(Vehicle vehicle);
    void Update(Vehicle vehicle);
    
}