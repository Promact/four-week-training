using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagementSystem.Interfaces;
using VehicleManagementSystem.Models;

namespace VehicleManagementSystem
{
    public class VehicleService
    {
        private readonly IVehicleRepository<Vehicle> vehicleRepository;
        private readonly VehicleLogger _logger;

        // it initialize the VehicleService with a repository and logger
        public VehicleService(IVehicleRepository<Vehicle> repository, VehicleLogger logger)
        {
            vehicleRepository = repository;
            _logger = logger;
        }

        /// <summary>
        /// It add a vehicle to the repository
        /// </summary>
        /// <param name="vehicle"></param>
        public void AddVehicle(Vehicle vehicle)
        {
            vehicleRepository.Add(vehicle);
            Console.ForegroundColor = ConsoleColor.Green;
            _logger.Log($"Added a {vehicle.Name} with Id {vehicle.Id}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// It remove a vehicle from the repository
        /// </summary>
        /// <param name="id"></param>
        public void RemoveVehicle(int id)
        {
            var vehicle = vehicleRepository.GetById(id);
            if (vehicle != null)
            {
                vehicleRepository.Delete(vehicle);
                Console.ForegroundColor = ConsoleColor.Green;
                _logger.Log($"Removed vehicle with Id {id}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// It log the list of vehicles 
        /// </summary>
        public void ListVehicles()
        {
            _logger.Log("List of Vehicles:");
            foreach (var vehicle in vehicleRepository.GetAll())
            {

                _logger.Log($"ID: {vehicle.Id}, Name: {vehicle.Name}");

            }
        }

        /// <summary>
        /// It perform an action on a specific vehicle (car/truck)
        /// </summary>
        /// <param name="id"></param>
        public void DoSomethingWithVehicle(int id)
        {
            var vehicle = vehicleRepository.GetById(id);
            if (vehicle != null)
            {
                _logger.Log($"Performing some action on vehicle with Id {id}");
            }
            else
            {
                _logger.Log($"Vehicle with Id {id} not found.");
            }
        }
    }
}
