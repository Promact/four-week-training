using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem
{
    internal class VehicleService
    {
        private IRepository<Entity> myrepository;
        private VehicleLogger mylogger;

        public VehicleService(IRepository<Entity> repository, VehicleLogger logger)
        {
            myrepository = repository;
            mylogger = logger;
        }

        public void AddVehicle(Entity vehicle)
        {
            myrepository.Add(vehicle);
            mylogger.Log($"Added vehicle: {vehicle.Name}");
        }

        public void RemoveVehicle(int id)
        {
            Entity vehicle = myrepository.GetById(id);
            if (vehicle != null)
            {
                myrepository.Delete(vehicle);
                mylogger.Log($"Removed vehicle: {vehicle.Name}");
            }
            else
            {
                mylogger.Log($"Vehicle not found for removal. ID: {id}");
            }
        }

        public void ListVehicles()
        {
            var vehicles = myrepository.GetAll();
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine($"ID: {vehicle.Id}, Model: {vehicle.Name}");
            }
        }

        public void DoSomethingWithVehicle(int id)
        {
            var vehicle = myrepository.GetById(id);
            if (vehicle != null)
            {
                mylogger.Log("Done");
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }
    }
}
