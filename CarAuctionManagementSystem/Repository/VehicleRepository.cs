using CarAuctionManagementSystem.Models;

namespace CarAuctionManagementSystem.Repository;

public class VehicleRepository : IVehicleRepository
{
    private readonly Dictionary<int, Vehicle> _vehicles = new();

    
    public Vehicle? GetById(int id)
    {
        
        
        if (_vehicles.ContainsKey(id))
            return _vehicles[id];
        
        return null;
    }
    

    public IEnumerable<Vehicle> GetAll()
    {
        return _vehicles.Values;
    }

    public IEnumerable<Vehicle> GetByType(VehicleType vehicleType)
    {
        return _vehicles.Values.Where(v => v.Type == vehicleType);
    }

    public IEnumerable<Vehicle> GetByManufacturer(string manufacturer)
    {
        return _vehicles.Values.Where(v => v.Manufacturer == manufacturer);
    }

    public IEnumerable<Vehicle> GetByModel(string model)
    {
        return _vehicles.Values.Where(v => v.Model == model);
    }

    public IEnumerable<Vehicle> GetByYear(int year)
    {
        return _vehicles.Values.Where(v => v.Year == year);
    }

    public void Insert(Vehicle vehicle)
    {
        _vehicles.Add(vehicle.Id, vehicle);

    }

    public void Update(Vehicle vehicle)
    {

        if (_vehicles.ContainsKey(vehicle.Id))
        {
            //todos os campos têm de ser *updated*
            _vehicles[vehicle.Id] = vehicle;
            
        }
    }
    
    
    
    
    
    
}