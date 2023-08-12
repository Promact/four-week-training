using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Interface
{
    public interface IRepository<T>
    {
        /// <summary>
        /// It return data based on firstName or title 
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        Task<T> GetByFirstNameAsync(string firstName);
        /// <summary>
        /// it return all the list of data
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();
        /// <summary>
        /// it;s add the data to list
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> AddAsync(T entity);
        /// <summary>
        /// it update the data of a existing one
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T entity);
        /// <summary>
        /// it delete the data from list based on firstname or title
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        Task<bool> DeleteByFirstAsync(string firstName);
    }
}
