using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem
{
    // The VehicleService class handles operations related to vehicles using a repository and logger.
    public class VehicleService
    {
        private readonly IRepository<IVehicle> _vehicleRepository; // Repository to store vehicles.
        private VehicleLogger _vehicleLogger; // Logger to record vehicle-related actions.

        // Constructor for VehicleService.
        public VehicleService(IRepository<IVehicle> vehicleRepository, VehicleLogger vehicleLogger)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleLogger = vehicleLogger;
        }

        // Adds a vehicle to the repository using a factory and logs the action.
        public void AddVehicle(VehicleFactory factory)
        {
            IVehicle vehicle = factory.CreateVehicle();
            _vehicleRepository.Add(vehicle);
            _vehicleLogger.Log("Vehicle added successfully");
        }

        // Removes a vehicle from the repository by ID and logs the action.
        public void RemoveVehicle(int id)
        {
            IVehicle vehicle = _vehicleRepository.GetById(id);
            if (vehicle != null)
            {
                _vehicleRepository.Delete(vehicle);
                _vehicleLogger.Log("Vehicle Removed Successfully.");
            }
            else
            {
                _vehicleLogger.Log("Vehicle Not Found.");
            }
        }

        // Lists all vehicles in the repository and invokes the Drive method for each vehicle.
        public void ListVehicles()
        {
            foreach (IVehicle vehicle in _vehicleRepository.GetAll())
            {
                vehicle.Drive();
            }
        }

        // Performs an action on a vehicle by ID, logs the action, and invokes the Drive method.
        public void DoSomethingWithVehicle(int id)
        {
            IVehicle vehicle = _vehicleRepository.GetById(id);
            if (vehicle != null)
            {
                vehicle.Drive();
                _vehicleLogger.Log("Something happened with the vehicle. Drive Slowly");
            }
        }
    }
}
