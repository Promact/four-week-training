using LibraryManagement.Models;
using LibraryManagement.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    public class BorrowerRepository : Repository<Borrower>, IBorrowerRepository
    {
        private readonly List<Borrower> _borrowers;
        public BorrowerRepository(List<Borrower> list) : base(list)
        {
            _borrowers = list;
        }

        public void Update(int index, Borrower borrower)
        {
            _borrowers[index] = borrower;
        }
    }
}
