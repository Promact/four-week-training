namespace VehicleManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepository<IVehicle> vehicleRepository = new VehicleRepository();
            VehicleService vehicleService = new VehicleService(vehicleRepository);

            VehicleFactory carFactory = new CarFactory();
            VehicleFactory truckFactory = new TruckFactory();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Please select option which vehicle you want to create \n 0 => car \n 1=>truck");
                int opt = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Please select option for operation \n 0=>Add \n 1=>Delete \n 2=>List Vehicle \n 3=>Exit");
                int operation = Convert.ToInt32(Console.ReadLine());

                if (operation == 0)
                {
                    if (opt == 0)
                        vehicleService.AddVehicle(carFactory);
                    else
                        vehicleService.AddVehicle(truckFactory);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Vehicle added successfully");

                }
                else if (operation == 1)
                {
                    Console.WriteLine("Write id that you want to delete : ");
                    int deleteId = Convert.ToInt32(Console.ReadLine());
                    vehicleService.RemoveVehicle(deleteId);
                }
                else if (operation == 2)
                {
                    vehicleService.ListVehicles();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("List of vehicles fetch successfully");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("End of operation");
                    break;
                }

            }

        }
    }
}