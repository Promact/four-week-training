using System;
using System.Collections.Generic;

// 1. IVehicle interface
public interface IVehicle
{
    void Drive();
}

// 2. Car and Truck classes
public class Car : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Car is driving.");
    }
}

public class Truck : IVehicle
{
    public void Drive()
    {
        Console.WriteLine("Truck is driving.");
    }
}

// 3. Singleton VehicleLogger class
public class VehicleLogger
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
        Console.WriteLine($"[Log] {message}");
    }
}

// 4. Abstract VehicleFactory class
public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();

    public void DoSomethingWithVehicle()
    {
        IVehicle vehicle = CreateVehicle();
        vehicle.Drive();
    }
}

// 5. Concrete factory classes
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

// 6. IRepository interface
public interface IRepository<T>
{
    T GetById(int id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}

// 7. VehicleRepository class
public class VehicleRepository : IRepository<IVehicle>
{
    private List<IVehicle> vehicles = new List<IVehicle>();

    public IVehicle GetById(int id)
    {
        return vehicles.FirstOrDefault(v => v.GetHashCode() == id);
    }

    public IEnumerable<IVehicle> GetAll()
    {
        return vehicles;
    }

    public void Add(IVehicle entity)
    {
        vehicles.Add(entity);
    }

    public void Update(IVehicle entity)
    {
        // Implement update logic
    }

    public void Delete(IVehicle entity)
    {
        vehicles.Remove(entity);
    }
}

// 8. VehicleService class
public class VehicleService
{
    private IRepository<IVehicle> repository;
    private VehicleLogger logger;

    public VehicleService(IRepository<IVehicle> repository)
    {
        this.repository = repository;
        logger = VehicleLogger.Instance;
    }

    public void AddVehicle(VehicleFactory factory)
    {
        IVehicle vehicle = factory.CreateVehicle();
        repository.Add(vehicle);
        logger.Log($"Added a new {vehicle.GetType().Name}");
    }

    public void RemoveVehicle(int id)
    {
        IVehicle vehicle = repository.GetById(id);
        if (vehicle != null)
        {
            repository.Delete(vehicle);
            logger.Log($"Removed {vehicle.GetType().Name}");
        }
        else
        {
            logger.Log("Vehicle not found.");
        }
    }

    public void ListVehicles()
    {
        foreach (var vehicle in repository.GetAll())
        {
            Console.WriteLine($"Vehicle: {vehicle.GetType().Name}");
        }
    }

    public void DoSomethingWithVehicle(int id)
    {
        IVehicle vehicle = repository.GetById(id);
        if (vehicle != null)
        {
            vehicle.Drive();
            logger.Log($"Performed action on {vehicle.GetType().Name}");
        }
        else
        {
            logger.Log("Vehicle not found.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        IRepository<IVehicle> repository = new VehicleRepository();
        VehicleService service = new VehicleService(repository);

        VehicleFactory carFactory = new CarFactory();
        VehicleFactory truckFactory = new TruckFactory();

        service.AddVehicle(carFactory);
        service.AddVehicle(truckFactory);

        service.ListVehicles();

        service.DoSomethingWithVehicle(1);
        service.DoSomethingWithVehicle(2);

        service.RemoveVehicle(1);
        service.ListVehicles();
    }
}
