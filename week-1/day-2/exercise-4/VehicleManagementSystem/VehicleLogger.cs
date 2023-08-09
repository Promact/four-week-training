using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem
{
    // Define a class for logging vehicle-related messages
    public class VehicleLogger
    {
        // Private constructor to prevent external instantiation
        private VehicleLogger() { }

        // Create an object for Thread Safety to use double check locking
        private static readonly object locker = new object();

        // Create a private instance variable for the singleton pattern
        private static VehicleLogger? instance;

        // Define a public property to access the singleton instance
        public static VehicleLogger Instance
        {
            get
            {
                // Thread Safety Singleton using Double-Check Locking
                if (instance == null)
                {
                    lock (locker)
                    {
                        // If instance is still null, create a new instance
                        if (instance == null)
                        {
                            instance = new VehicleLogger();
                        }
                    }
                }
                // Return the singleton instance
                return instance;
            }
        }

        // Method for logging vehicle-related messages
        public void Log(string message)
        {
            Console.WriteLine($"Vehicle Logging: {message}");
        }
    }
}
