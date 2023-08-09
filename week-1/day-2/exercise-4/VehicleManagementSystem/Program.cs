namespace VehicleManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to input a vehicle type
            Console.WriteLine("1. Factory Design Method.");
            Console.Write("Enter a vehicle type car or truck: ");
            string? vehicleType = Console.ReadLine();
            // Retrieve the appropriate vehicle factory based on user input
            VehicleFactory vehicleFactory = GetVehicleFactory(vehicleType);

            if (vehicleFactory != null)
            {
                // Use the factory to create a vehicle and perform a drive action
                IVehicle vehicle = vehicleFactory.CreateVehicle();
                Console.WriteLine("\nVehicle created:");
                vehicle.Drive();
            }
            else
            {
                Console.WriteLine("Invalid vehicle type.");
            }

            Console.WriteLine("\n2.Repository CRUD operation.\n");

            // Create instances of VehicleRepository and VehicleLogger
            VehicleRepository vehicleRepository = new VehicleRepository();
            VehicleLogger vehicleLogger = VehicleLogger.Instance;

            // Create a VehicleService and associate it with the repository and logger
            VehicleService vehicleService = new VehicleService(vehicleRepository, vehicleLogger);

            // Create instances of CarFactory and TruckFactory
            CarFactory carFactory = new CarFactory();
            TruckFactory truckFactory = new TruckFactory();

            // List vehicles and demonstrate adding/removing vehicles
            vehicleService.AddVehicle(carFactory);
            vehicleService.AddVehicle(carFactory);
            vehicleService.AddVehicle(truckFactory);

            vehicleService.ListVehicles();
            vehicleService.RemoveVehicle(1);
            vehicleService.AddVehicle(truckFactory);
            vehicleService.ListVehicles();

            // Demonstrate performing actions on vehicles
            vehicleService.DoSomethingWithVehicle(1);
            vehicleService.DoSomethingWithVehicle(2);
        }

        // Helper function to get the appropriate vehicle factory based on input
        static VehicleFactory GetVehicleFactory(string vehicleType)
        {
            switch (vehicleType.ToLower())
            {
                case "car":
                    return new CarFactory();
                case "truck":
                    return new TruckFactory();
                default:
                    return null;
            }
        }
    }
}