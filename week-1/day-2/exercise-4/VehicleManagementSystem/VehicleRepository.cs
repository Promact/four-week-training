using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem
{
    // This class implements the IRepository interface for IVehicle objects.
    public class VehicleRepository : IRepository<IVehicle>
    {
        // Private dictionary to store vehicles with their unique IDs.
        private Dictionary<int, IVehicle> vehicles = new Dictionary<int, IVehicle>();

        // Used to generate the next available ID for new vehicles.
        private int nextId = 1;

        // Adds a new vehicle to the repository.
        public void Add(IVehicle entity)
        {
            int id = nextId++;
            vehicles[id] = entity;
        }

        // Deletes a vehicle from the repository.
        public void Delete(IVehicle entity)
        {
            // Find the key-value pair associated with the specified entity.
            var item = vehicles.FirstOrDefault(v => v.Value == entity);

            // If the entity is found, remove it from the dictionary.
            if (item.Value != null)
            {
                vehicles.Remove(item.Key);
            }
        }

        // Retrieves all vehicles from the repository.
        public IEnumerable<IVehicle> GetAll()
        {
            return vehicles.Values;
        }

        // Retrieves a vehicle by its ID from the repository.
        public IVehicle GetById(int id)
        {
            // Try to get the vehicle associated with the given ID.
            vehicles.TryGetValue(id, out IVehicle vehicle);
            return vehicle;
        }

        // Updates a vehicle in the repository (not implemented in this version).
        public void Update(IVehicle entity)
        {
            throw new NotImplementedException();
        }
    }
}
