using System.Diagnostics;
using VehicleManagementSystem.Interfaces;
using VehicleManagementSystem.Models;

namespace VehicleManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Factory method call using Factory Design pattern 
            VehicleFactory carFactory = new CarFactory();
            carFactory.DoSomethingWithVehicle();

            VehicleFactory truckFactory = new TruckFactory();
            truckFactory.DoSomethingWithVehicle();

            // Create an instance of the VehicleRepository implementing IRepository<Vehicle>
            IVehicleRepository<Vehicle> repository = new VehicleRepository();

            // Create a VehicleService instance using the VehicleRepository and VehicleLogger
            VehicleService service = new VehicleService(repository, VehicleLogger.Instance);

            // Add vehicles
            service.AddVehicle(new Car { Name = "Honda" });
            service.AddVehicle(new Truck { Name = "TATA" });

            // List vehicles
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n------------- List of vehicles --------------\n");
            Console.ForegroundColor = ConsoleColor.White;
            service.ListVehicles();
            service.DoSomethingWithVehicle(1);

            //Remove Vehicle by Id
            service.RemoveVehicle(2);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n------------- List of vehicles --------------\n");
            Console.ForegroundColor = ConsoleColor.White;

            // List Vehicle
            service.ListVehicles();
        }
    }
}