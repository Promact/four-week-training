using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleManagementSystem.Interfaces;
using VehicleManagementSystem.Models;

namespace VehicleManagementSystem
{
    public class Truck : Vehicle, IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Truck is moving");
        }
    }
}
