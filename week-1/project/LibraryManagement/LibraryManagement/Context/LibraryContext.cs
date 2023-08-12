using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Context
{
    public class LibraryContext
    {
        public List<Book> Books { get; set; } = new List<Book>
        {
            new Book { Title = "BookOne", Author = new Author { FirstName = "abc", LastName = "Kumar", DateOfBirth = new DateTime(1999, 07, 07) }, PublicationYear = 2020, IsAvailable = true },
            new Book { Title = "BookTwo", Author = new Author { FirstName = "xyz", LastName = "Kumar", DateOfBirth = new DateTime(2000, 09, 01) }, PublicationYear = 2018, IsAvailable = false }
        };
        public List<Author> Authors { get; set; } = new List<Author>()
        {
            new Author { FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1980, 1, 15) },
            new Author { FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1975, 5, 10) }
        };

        public List<Borrower> Borrowers { get; set; } = new List<Borrower>()
        {
            new Borrower { FirstName = "Vipul", LastName = "Kumar", Email = "vipul@gamil.com", PhoneNumber = "123-456-7890" },
            new Borrower { FirstName = "Divyanshu", LastName = "Kumar", Email = "divu@gamil.com", PhoneNumber = "987-654-3210" }
        };
        public List<BorrowedBook> BorrowedBooks { get; set; } = new List<BorrowedBook>()
        {
             new BorrowedBook
        {
            Book = new Book { Title = "Book One", PublicationYear = 2020, IsAvailable = true },
            Borrower = new Borrower { FirstName = "Vipul", LastName = "Kumar", Email = "vipul@gamil.com", PhoneNumber = "123-456-7890" },
            BorrowDate = DateTime.Now.AddDays(-7),
            DueDate = DateTime.Now.AddDays(7)
        },
        new BorrowedBook
        {
            Book = new Book { Title = "Book Two", PublicationYear = 2018, IsAvailable = false },
            Borrower = new Borrower { FirstName = "Divyanshu", LastName = "Kumar", Email = "divu@gamil.com", PhoneNumber = "987-654-3210" },
            BorrowDate = DateTime.Now.AddDays(-14),
            DueDate = DateTime.Now.AddDays(0)
        }
        };
    }
}
