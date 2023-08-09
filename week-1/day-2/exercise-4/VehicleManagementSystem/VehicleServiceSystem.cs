using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem
{
    public interface IVehicle
    {
        int id { get; set; }
        public void Drive();
    }

    public class Car : IVehicle
    {
        public int id { get; set; }

        public Car(int id)
        {
            this.id = id;
        }
        public void Drive()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Car's max speed is 140km/h");
        }
    }

    public class Truck : IVehicle
    {

        public int id { get; set; }
        public Truck(int id)
        {
            this.id = id;
        }

        public void Drive()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Truck's max speed is 80km/h");
        }
    }

    public class VehicleLogger
    {
        private static VehicleLogger instance;

        private VehicleLogger()
        {
        }

        public static VehicleLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new VehicleLogger();
            }
            return instance;
        }

        public void Log(string message)
        {
            Console.WriteLine("Logging: " + message);
        }
    }

    public abstract class VehicleFactory
    {

        public int idCounter = 0;

        public abstract IVehicle CreateVehicle();

        public void doSomethingWithVehicle()
        {
            IVehicle vehicle = CreateVehicle();
            vehicle.Drive();
        }

        public int generateId()
        {
            return idCounter++;
        }

    }

    public class CarFactory : VehicleFactory
    {
        //create carFactory instance
        public override IVehicle CreateVehicle()
        {
            return new Car(generateId());
        }
    }

    public class TruckFactory : VehicleFactory
    {
        //create truckFactory instance
        public override IVehicle CreateVehicle()
        {
            return new Truck(generateId());
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
        private List<IVehicle> vehicles;
        public int nextId = 0;

        //in this constructor creating new instance for list of type IVehicles
        public VehicleRepository()
        {
            vehicles = new List<IVehicle>();
        }

        private int GenerateId()
        {
            return nextId++;
        }

        public IVehicle GetById(int id)
        {
            return vehicles.FirstOrDefault(v => v.id == id);
        }

        public IEnumerable<IVehicle> GetAll()
        {
            return vehicles;
        }

        public void Add(IVehicle entity)
        {
            entity.id = GenerateId();
            vehicles.Add(entity);
        }

        public void Update(IVehicle entity)
        {
            var existingEntity = vehicles.FirstOrDefault(e => e.id == entity.id);
            if (existingEntity != null)
            {

            }
        }

        public void Delete(IVehicle entity)
        {
            vehicles.Remove(entity);
        }
    }

    public class VehicleService
    {
        private IRepository<IVehicle> repository;
        private VehicleLogger logger;

        public VehicleService(IRepository<IVehicle> repository)
        {
            this.repository = repository;
            this.logger = VehicleLogger.GetInstance();
        }

        public void AddVehicle(VehicleFactory factory)
        {
            IVehicle vehicle = factory.CreateVehicle();
            repository.Add(vehicle);
        }

        public void RemoveVehicle(int id)
        {
            IVehicle vehicle = repository.GetById(id);
            if (vehicle != null && repository != null)
            {
                repository.Delete(vehicle);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vehicle delete successfully");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Vehicle with ID {id} not found. Cannot remove.");
            }
        }

        public void ListVehicles()
        {
            foreach (var vehicle in repository.GetAll())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Vehicle {vehicle.id} is a {vehicle.GetType().Name}");
            }
        }

        public void DoSomethingWithVehicle(int id)
        {
            IVehicle vehicle = repository.GetById(id);
            if (vehicle != null)
            {
                vehicle.Drive();
            }
        }

    }
}
