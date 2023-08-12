using LibraryManagement.Interface;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class BorrowerService : IRepository<Borrower>
    {
        private readonly IRepository<Borrower> _repository;

        public BorrowerService(IRepository<Borrower> repository)
        {
            _repository = repository;
        }

        public async Task<Borrower> GetByFirstNameAsync(string firstName)
        {
            return await _repository.GetByFirstNameAsync(firstName);
        }

        public async Task<List<Borrower>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<bool> AddAsync(Borrower entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task<bool> UpdateAsync(Borrower entity)
        {
            return await _repository.UpdateAsync(entity);
        }

        public async Task<bool> DeleteByFirstAsync(string firstName)
        {
            return await _repository.DeleteByFirstAsync(firstName);
        }
    }
}
