namespace VehicleManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Car myCar = new Car();
            Truck myTruck = new Truck();

            myCar.Drive();
            myTruck.Drive();

            VehicleFactory carFactory = new CarFactory();
            carFactory.DoSomethingWithVehicle();

            VehicleFactory truckFactory = new TruckFactory();
            truckFactory.DoSomethingWithVehicle();

            IRepository<Entity> repository = new VehicleRepository();
            VehicleService vehicleService = new VehicleService(repository, VehicleLogger.GetInstance());

            repository.Add(new Entity { Name = "E1" });
            repository.Add(new Entity { Name = "E2" });

            var allEntities = repository.GetAll();
            foreach (var entity in allEntities)
            {
                Console.WriteLine($"ID: {entity.Id}, Name: {entity.Name}");
            }

            var entityToUpdate = repository.GetById(1);
            if (entityToUpdate != null)
            {
                entityToUpdate.Name = "Updated E1";
                repository.Update(entityToUpdate);
            }

            var entityToDelete = repository.GetById(2);
            if (entityToDelete != null)
            {
                repository.Delete(entityToDelete);
            }

            Console.WriteLine("\nAfter Update and Delete:");
            foreach (var entity in repository.GetAll())
            {
                Console.WriteLine($"ID: {entity.Id}, Name: {entity.Name}");
            }
            Entity car = (Entity)carFactory.CreateVehicle();
            car.Id = 1;
            car.Name = "Audi";
            Entity truck = (Entity)truckFactory.CreateVehicle();
            truck.Id = 2;
            truck.Name = "Mahindra";

            vehicleService.AddVehicle(car);
            vehicleService.AddVehicle(truck);

            // Listing vehicles
            Console.WriteLine("List of vehicles:");
            vehicleService.ListVehicles();

            // Doing something with a vehicle
            Console.WriteLine("\nDoing something with a vehicle:");
            vehicleService.DoSomethingWithVehicle(1);


            vehicleService.RemoveVehicle(2);

            Console.ReadLine();
        }
    }
}