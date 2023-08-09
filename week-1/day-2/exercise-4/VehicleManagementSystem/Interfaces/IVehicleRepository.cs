using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleManagementSystem.Interfaces
{
    public interface IVehicleRepository<T>
    {
        /// <summary>
        /// It return a vehicle
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);
        /// <summary>
        /// It return all the vehicle 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// It add vehicle into List 
        /// </summary>
        /// <param name="vehicle"></param>
        void Add(T vehicle);
        /// <summary>
        /// It Update the vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        void Update(T vehicle);
        /// <summary>
        /// It delete the vehicle from list
        /// </summary>
        /// <param name="vehicle"></param>
        void Delete(T vehicle);
    }
}
