using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem
{
    public sealed class VehicleLogger
    {
        private static VehicleLogger? _instance;
        private static readonly object lockObject = new object();

        // Private constructor to prevent instantiation
        private VehicleLogger() { }

        public static VehicleLogger Instance
        {
            get
            {
                // Double-check locking to ensure thread safety
                if (_instance == null)
                {
                    // It handle the singleton instance in a multithread environment
                    lock (lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new VehicleLogger();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine($"Log: {DateTime.Now} : {message}");
        }
    }
}
