using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAY2
{
    internal class Vehicle
    {
        static void Main(string[] args)
        {
            {
                Car car = new Car();
                Truck truck = new Truck();

                car.Drive();
                truck.Drive();
            }
            {
                VehicleLogger logger = VehicleLogger.Instance;

                logger.Log("Car ignition turned on.");
                logger.Log("Truck started.");

            }
            {
                VehicleFactory carFactory = new CarFactory();
                VehicleFactory truckFactory = new TruckFactory();

                carFactory.DoSomethingWithVehicle();
                truckFactory.DoSomethingWithVehicle();

            }


        }



    }
}
public interface Ivehicle
{
    void Drive();


}
public class Car : Ivehicle
{
    public void Drive()
    {
        Console.WriteLine("Car is moving.");
    }
}
public class Truck : Ivehicle
{
    public void Drive()
    {
        Console.WriteLine("Truck is moving.");
    }
}
public class VehicleLogger
{
    private static VehicleLogger instance;
    private VehicleLogger()
    {

    }
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
        Console.WriteLine($"Logging: {message}");
    }
}
public abstract class VehicleFactory
{
    public abstract Ivehicle CreateVehicle();

    public void DoSomethingWithVehicle()
    {
        Ivehicle vehicle = CreateVehicle();
        Console.WriteLine("Do something with vehicle ");
        vehicle.Drive();
    }


}
public class CarFactory : VehicleFactory
{
    public override Ivehicle CreateVehicle()
    {
        return new Car();
    }
}

public class TruckFactory : VehicleFactory
{
    public override Ivehicle CreateVehicle()
    {
        return new Truck();
    }
}
