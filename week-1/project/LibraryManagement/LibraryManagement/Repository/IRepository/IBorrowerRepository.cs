using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository.IRepository
{
    public interface IBorrowerRepository : IRepository<Borrower>
    {
        void Update(int index, Borrower borrower);
    }
}
