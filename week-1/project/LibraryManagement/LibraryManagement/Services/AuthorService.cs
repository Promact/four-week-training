using LibraryManagement.Interface;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class AuthorService : IRepository<Author>
    {
        private readonly IRepository<Author> _repository;

        public AuthorService(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<Author> GetByFirstNameAsync(string firstName)
        {
            Author author = await _repository.GetByFirstNameAsync(firstName);
            return author;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> AddAsync(Author entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(Author entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteByFirstAsync(string firstName)
        {
            bool IsDeleted = await _repository.DeleteByFirstAsync(firstName);
            return IsDeleted;
        }
    }
}
