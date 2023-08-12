using LibraryManagement.Interface;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class BookService : IRepository<Book>
    {
        private readonly IRepository<Book> _repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<Book> GetByFirstNameAsync(string title)
        {
            return await _repository.GetByFirstNameAsync(title);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> AddAsync(Book entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(Book entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteByFirstAsync(string title)
        {
            return await _repository.DeleteByFirstAsync(title);
        }
    }
}
