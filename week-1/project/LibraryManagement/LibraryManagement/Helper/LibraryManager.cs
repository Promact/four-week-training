using LibraryManagement.Interface;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Helper
{
    public class LibraryManager
    {
        /// <summary>
        /// Ijecting all services 
        /// </summary>
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<Borrower> _borrowerRepository;
        private readonly IRepository<BorrowedBook> _borrowedBookRepository;

        public LibraryManager(
            IRepository<Book> bookRepository,
            IRepository<Author> authorRepository,
            IRepository<Borrower> borrowerRepository,
            IRepository<BorrowedBook> borrowedBookRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _borrowerRepository = borrowerRepository;
            _borrowedBookRepository = borrowedBookRepository;
        }

        #region Book Service
        /// <summary>
        /// get bool list
        /// </summary>
        /// <returns></returns>
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }
        /// <summary>
        /// get book by it's title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<Book> GetBookByTitleAsync(string title)
        {
            return await _bookRepository.GetByFirstNameAsync(title);
        }
        /// <summary>
        /// add new book to list
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task<bool> AddBookAsync(Book book)
        {
            return await _bookRepository.AddAsync(book);
        }
        /// <summary>
        /// update book 
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task<bool> UpdateBookAsync(Book book)
        {
            return await _bookRepository.UpdateAsync(book);
        }
        /// <summary>
        /// delete book by it's title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBookAsync(string title)
        {
            return await _bookRepository.DeleteByFirstAsync(title);
        }
        #endregion Book Service

        #region Author Service
        /// <summary>
        /// get all author list
        /// </summary>
        /// <returns></returns>
        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _authorRepository.GetAllAsync();
        }
        /// <summary>
        /// get author by it's first name
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public async Task<Author> GetAuthorByFirstName(string firstName)
        {
            return await _authorRepository.GetByFirstNameAsync(firstName);
        }
        /// <summary>
        /// add new author to list
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public async Task<bool> AddAuthorAsync(Author author)
        {
            return await _authorRepository.AddAsync(author);
        }
        /// <summary>
        /// update author data 
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAuthorAsync(Author author)
        {
            return await _authorRepository.UpdateAsync(author);
        }
        /// <summary>
        /// delete author by it's first name
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAuthorByFirstNameAsync(string firstName)
        {
            return await _authorRepository.DeleteByFirstAsync(firstName);
        }
        #endregion Author Service

        #region Borrower Service
        /// <summary>
        /// get all borrower list
        /// </summary>
        /// <returns></returns>
        public async Task<List<Borrower>> GetAllBorrowersAsync()
        {
            return await _borrowerRepository.GetAllAsync();
        }
        /// <summary>
        /// get borrow by it's first name
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public async Task<Borrower> GetBorrowerByFirstNameAsync(string firstName)
        {
            return await _borrowerRepository.GetByFirstNameAsync(firstName);
        }
        /// <summary>
        /// Add borrower to list
        /// </summary>
        /// <param name="borrower"></param>
        /// <returns></returns>
        public async Task<bool> AddBorrowerAsync(Borrower borrower)
        {
            return await _borrowerRepository.AddAsync(borrower);
        }
        /// <summary>
        /// update borrower 
        /// </summary>
        /// <param name="borrower"></param>
        /// <returns></returns>
        public async Task<bool> UpdateBorrowerAsync(Borrower borrower)
        {
            return await _borrowerRepository.UpdateAsync(borrower);
        }
        /// <summary>
        /// delete borrower by it's first name
        /// </summary>
        /// <param name="firstName"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBorrowerByFirstNameAsync(string firstName)
        {
            return await _borrowerRepository.DeleteByFirstAsync(firstName);
        }
        #endregion Borrower Service

        #region Miscellaneous Service
        /// <summary>
        /// it register book to borrower
        /// </summary>
        /// <param name="title"></param>
        /// <param name="borrowerFirstName"></param>
        /// <returns></returns>
        public async Task<bool> RegisterBookToBorrowerAsync(string title, string borrowerFirstName)
        {
            Book book = await _bookRepository.GetByFirstNameAsync(title);
            Borrower borrower = await _borrowerRepository.GetByFirstNameAsync(borrowerFirstName);

            if (book != null && borrower != null)
            {
                if (book.IsAvailable)
                {
                    BorrowedBook borrowedBook = new BorrowedBook
                    {
                        Book = book,
                        Borrower = borrower,
                        BorrowDate = DateTime.Now,
                        DueDate = DateTime.Now.AddDays(14) // Set a due date 14 days from now
                    };

                    await _borrowedBookRepository.AddAsync(borrowedBook);
                    book.IsAvailable = false;
                    // Book successfully registered to the borrower
                    return true;
                }
                else
                {
                    Console.WriteLine("Book is already borrowed.");
                }
            }
            // Book or borrower not found, or registration failed
            return false;
        }
        /// <summary>
        /// it return all borrow book list
        /// </summary>
        /// <returns></returns>
        public async Task<List<BorrowedBook>> GetAllBorrowedBooksAsync()
        {
            return await _borrowedBookRepository.GetAllAsync();
        }
        /// <summary>
        /// Seach book by it's title
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<List<Book>> SearchBooksAsync(string keyword)
        {
            List<Book> books = await _bookRepository.GetAllAsync();
            List<Book> filteredBooks = books.Where(book => book.Title!.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
            return filteredBooks;
        }
        /// <summary>
        /// filter book by it's availability
        /// </summary>
        /// <param name="isAvailable"></param>
        /// <returns></returns>
        public async Task<List<Book>> FilterBooksByStatusAsync(bool isAvailable)
        {
            List<Book> books = await _bookRepository.GetAllAsync();
            List<Book> filteredBooks = books.Where(x => x.IsAvailable == isAvailable).ToList();
            return filteredBooks;
        }
        #endregion Miscellaneous Service
    }
}
