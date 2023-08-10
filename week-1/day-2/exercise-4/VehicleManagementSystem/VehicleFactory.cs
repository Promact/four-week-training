using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem
{
    // Abstract factory class that defines a method for creating vehicles
    public abstract class VehicleFactory
    {
        // Abstract method for creating a vehicle
        public abstract IVehicle CreateVehicle();

        // Method that demonstrates using the created vehicle
        public void DoSomethingWithVehicle()
        {
            // Create a vehicle using the factory method
            IVehicle vehicle = CreateVehicle();

            // Drive the created vehicle
            vehicle.Drive();
        }
    }

    // Concrete factory class that creates cars
    public class CarFactory : VehicleFactory
    {
        // Override the CreateVehicle method to create a car
        public override IVehicle CreateVehicle()
        {
            return new Car();
        }
    }

    // Concrete factory class that creates trucks
    public class TruckFactory : VehicleFactory
    {
        // Override the CreateVehicle method to create a truck
        public override IVehicle CreateVehicle()
        {
            return new Truck();
        }
    }
}
