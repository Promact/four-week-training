using LibraryManagement.Models;
using LibraryManagement.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    public class BorrowedBookRepository : Repository<BorrowedBook>, IBorrowedBookRepository
    {
        private readonly List<BorrowedBook> _borrowedBooks;
        public BorrowedBookRepository(List<BorrowedBook> list) : base(list)
        {
            _borrowedBooks = list;
        }
    }
}
