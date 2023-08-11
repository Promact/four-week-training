using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem
{
    internal sealed class VehicleLogger
    {
        private static VehicleLogger instance = null;

        private VehicleLogger() { }

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
            Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
        }
    }

}
