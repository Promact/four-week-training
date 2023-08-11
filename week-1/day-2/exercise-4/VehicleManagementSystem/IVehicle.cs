using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem
{
    // Define an interface for vehicles.
    public interface IVehicle
    {
        void Drive();
    }

    // Define a class representing a Car, which implements the IVehicle interface.
    public class Car : IVehicle
    {
        // Implement the Drive method for the Car class.
        public void Drive()
        {
            Console.WriteLine("Driving Car.");
        }
    }

    // Define a class representing a Truck, which implements the IVehicle interface.
    public class Truck : IVehicle
    {
        // Implement the Drive method for the Truck class.
        public void Drive()
        {
            Console.WriteLine("Driving Truck.");
        }
    }
}
