using LibraryManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    public class StaticDataRepository<T> : IRepository<T>
    {
        private readonly List<T> _data;
        private readonly string _propertyToMatch;

        public StaticDataRepository(List<T> data, string propertyToMatch)
        {
            _data = data;
            _propertyToMatch = propertyToMatch;
        }
        /// <summary>
        /// it return all the list of their class
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetAllAsync()
        {
            return _data.ToList();
        }
        /// <summary>
        /// It add the propery to it's list
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(T entity)
        {
            _data.Add(entity);
            return true;
        }
        /// <summary>
        /// it's update the propery of existing data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(T entity)
        {
            var propertyToMatch = _propertyToMatch;
            var property = entity!.GetType().GetProperty(propertyToMatch);

            if (property != null)
            {
                var propertyValue = property.GetValue(entity)?.ToString();
                T existingEntity = _data.FirstOrDefault(item => string.Equals(property.GetValue(item)?.ToString(), propertyValue, StringComparison.OrdinalIgnoreCase))!;

                if (existingEntity != null)
                {
                    int index = _data.IndexOf(existingEntity);
                    _data[index] = entity;
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// getting the data based on firstName or title
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public Task<T> GetByFirstNameAsync(string firstName)
        {
            var property = typeof(T).GetProperty(_propertyToMatch);
            if (property != null)
            {
                T entity = _data.FirstOrDefault(item => string.Equals(property.GetValue(item)?.ToString(), firstName, StringComparison.OrdinalIgnoreCase))!;
                return Task.FromResult(entity);
            }

            return Task.FromResult(default(T))!;
        }
        /// <summary>
        /// it delete the data based on their firstName or title
        /// </summary>
        /// <param name="propName"></param>
        /// <returns></returns>
        public async Task<bool> DeleteByFirstAsync(string propName)
        {
            var property = typeof(T).GetProperty(_propertyToMatch);
            if (property != null)
            {
                T entityToDelete = _data.FirstOrDefault(item => string.Equals(property.GetValue(item)?.ToString(), propName, StringComparison.OrdinalIgnoreCase))!;

                if (entityToDelete != null)
                {
                    _data.Remove(entityToDelete);
                    return true;
                }
            }
            return false;
        }
    }
}
