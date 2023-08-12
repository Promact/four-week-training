using LibraryManagement.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _list;
        public Repository(List<T> list)
        {
            _list = list;
        }

        public void Add(T entity)
        {
            _list.Add(entity);
        }

        public void Delete(int index)
        {
            _list.RemoveAt(index);
        }

        public List<T> GetAll()
        {
            return _list;
        }
    }
}
