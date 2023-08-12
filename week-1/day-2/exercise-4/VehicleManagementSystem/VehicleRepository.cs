using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagementSystem.Interfaces;
using VehicleManagementSystem.Models;

namespace VehicleManagementSystem
{
    class VehicleRepository : IVehicleRepository<Vehicle>
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
        // counter for generating unique Id
        private int nextId = 1;

        /// <summary>
        /// retrive a vehicle by it's id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Vehicle GetById(int id)
        {
            return vehicles.Find(v => v.Id == id)!;
        }

        /// <summary>
        /// It Retrieve all vehicles from list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Vehicle> GetAll()
        {
            return vehicles;
        }

        /// <summary>
        /// It Add Vehicle to list
        /// </summary>
        /// <param name="vehicle"></param>
        public void Add(Vehicle vehicle)
        {
            vehicle.Id = nextId++;
            vehicles.Add(vehicle);
        }

        /// <summary>
        /// It Update the Vehicle 
        /// </summary>
        /// <param name="vehicle"></param>
        public void Update(Vehicle vehicle)
        {
            int index = vehicles.FindIndex(v => v.Id == vehicle.Id);
            if (index >= 0)
            {
                //  It replace the existing vehicle with the updated vehicle
                vehicles[index] = vehicle;
            }
        }

        /// <summary>
        /// It delete a vehicle from the repository
        /// </summary>
        /// <param name="vehicle"></param>
        public void Delete(Vehicle vehicle)
        {
            vehicles.Remove(vehicle);
        }
    }
}
