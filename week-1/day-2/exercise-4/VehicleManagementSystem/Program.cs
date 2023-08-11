namespace VehicleManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to VehicleManagementSystem");

            IRepository<IVehicle> vehicleRepository = new VehicleRepository();
            VehicleService vehicleService = new VehicleService(vehicleRepository);

            while (true)

            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Remove Vehicle");
                Console.WriteLine("3. Show Vehicles");
                Console.WriteLine("4. Exit");
                Console.ResetColor();
                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Blue;

                            Console.WriteLine("Choose a vehicle type:  Car or  Truck");
                            String vehicleTypeChoice = Console.ReadLine();
                            Console.ResetColor();
                            if (vehicleTypeChoice == "Car" || vehicleTypeChoice == "car")
                            {
                                vehicleService.AddVehicle(new CarFactory());
                            }
                            else if (vehicleTypeChoice == "Truck" || vehicleTypeChoice == "truck")
                            {
                                vehicleService.AddVehicle(new TruckFactory());
                            }

                            break;

                        case 2:
                            Console.WriteLine("Enter the ID of the vehicle to remove:");
                            Int16 idToRemove = Convert.ToInt16(Console.ReadLine());
                            vehicleService.RemoveVehicle(idToRemove);
                            break;

                        case 3:

                            vehicleService.ListVehicles();
                            break;

                        case 4:
                            return;

                        default:
                            Console.WriteLine("invalid choice !");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                }


                VehicleLogger logger = VehicleLogger.Instance;
                logger.Log("Vehicle operation completed");


            }

        }

        public interface IVehicle
        {
            int Id { get; set; }
            void Drive();
        }

        public class Car : IVehicle
        {
            public int Id { get; set; }
            public void Drive()
            {
                ;
                Console.WriteLine("driving a car with speed 120km/hour");

            }
        }


        public class Truck : IVehicle
        {
            public int Id { get; set; }
            public void Drive()
            {
                Console.WriteLine("driving a truck with speed 20km/hour");

            }
        }
        public sealed class VehicleLogger
        {
            private static VehicleLogger instance;
            private VehicleLogger() { }

            public static VehicleLogger Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new VehicleLogger();
                    }
                    return instance;
                }
            }

            public void Log(string message)
            {
                Console.WriteLine("Logging:" + message);
            }
        }
        public abstract class VehicleFactory
        {
            public abstract IVehicle CreateVehicle();

            public void DoSomethingWithVehicle()
            {
                IVehicle vehicle = CreateVehicle();
                Console.WriteLine("vehicle created !");
                vehicle.Drive();
            }
        }
        public class CarFactory : VehicleFactory
        {
            public override IVehicle CreateVehicle()
            {
                return new Car();
            }
        }

        public class TruckFactory : VehicleFactory
        {
            public override IVehicle CreateVehicle()
            {
                return new Truck();
            }
        }

        public interface IRepository<T>
        {
            T GetById(int id);
            IEnumerable<T> GetAll();
            void Add(T entity);
            void Update(T entity);
            void Delete(T entity);
        }
        public class VehicleRepository : IRepository<IVehicle>
        {
            private List<IVehicle> vehicles = new List<IVehicle>();
            public void Add(IVehicle entity)
            {
                entity.Id = GenerateNextId();
                vehicles.Add(entity);
            }
            public IVehicle GetById(int id)
            {
                return vehicles.FirstOrDefault(vehicle => vehicle.Id == id);
            }

            public IEnumerable<IVehicle> GetAll()
            {
                return vehicles;
            }




            public void Update(IVehicle entity)
            {
                IVehicle existingVehicle = vehicles.FirstOrDefault(vehicle => vehicle.Id == entity.Id);
                if (existingVehicle != null)
                {
                    // Update logic here
                }
            }
            private int GenerateNextId()
            {
                if (vehicles.Count == 0)
                {
                    return 1;
                }
                return vehicles.Max(vehicle => vehicle.Id) + 1;
            }
            public void Delete(IVehicle entity)
            {
                vehicles.Remove(entity);
            }
        }
        public class VehicleService
        {
            private readonly IRepository<IVehicle> vehicleRepository;

            public VehicleService(IRepository<IVehicle> repository)
            {
                vehicleRepository = repository;
            }

            public void AddVehicle(VehicleFactory factory)
            {
                IVehicle vehicle = factory.CreateVehicle();
                vehicleRepository.Add(vehicle);
            }

            public void RemoveVehicle(int id)
            {
                IVehicle vehicle = vehicleRepository.GetById(id);
                if (vehicle != null)
                {
                    vehicleRepository.Delete(vehicle);
                }
            }

            public void ListVehicles()
            {
                IEnumerable<IVehicle> vehicles = vehicleRepository.GetAll();

                foreach (var vehicle in vehicles)
                {
                    if (vehicle is Car)
                    {

                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Vehicle ID :" + vehicle.Id + " , Vehicle Name : Car ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Vehicle ID :" + vehicle.Id + " , Vehicle Name : Truck ");
                        Console.ResetColor();
                    }

                }
            }

            public void DoSomethingWithVehicle(int id)
            {
                IVehicle vehicle = vehicleRepository.GetById(id);
                if (vehicle != null)
                {
                    // Perform some action with the vehicle

                    Console.WriteLine("do nothing with vehicle !");

                }
            }
        }

    }
}