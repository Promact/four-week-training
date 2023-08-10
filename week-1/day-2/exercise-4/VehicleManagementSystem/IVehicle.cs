using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem
{
    internal interface IVehicle
    {
        public void Drive();
    }
    class Car : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Car contains people.");
        }
    }

    class Truck : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Truck contains heavy goods.");
        }
    }
}
