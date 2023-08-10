using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem
{
    internal abstract class VehicleFactory
    {
        public abstract IVehicle CreateVehicle();
        public void DoSomethingWithVehicle()
        {
            IVehicle vehicle = CreateVehicle();
            Console.WriteLine("The vehicle");
            vehicle.Drive();
        }
    }
    class CarFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle()
        {
            return new Car();
        }
    }

    class TruckFactory : VehicleFactory
    {
        public override IVehicle CreateVehicle()
        {
            return new Truck();
        }
    }
}
