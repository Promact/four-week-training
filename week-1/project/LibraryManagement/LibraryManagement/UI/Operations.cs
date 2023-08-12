using LibraryManagement.Context;
using LibraryManagement.Helper;
using LibraryManagement.Interface;
using LibraryManagement.Models;
using LibraryManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.UI
{
    public class Operations
    {
        private IRepository<Book> bookRepository;
        private IRepository<Author> authorRepository;
        private IRepository<Borrower> borrowerRepository;
        private IRepository<BorrowedBook> borrowedBookRepository;
        private LibraryContext context;
        private LibraryManager _libraryManager;
        public Operations()
        {
            context = new LibraryContext();
            bookRepository = new StaticDataRepository<Book>(context.Books, "Title");
            authorRepository = new StaticDataRepository<Author>(context.Authors, "FirstName");
            borrowerRepository = new StaticDataRepository<Borrower>(context.Borrowers, "FirstName");
            borrowedBookRepository = new StaticDataRepository<BorrowedBook>(context.BorrowedBooks, "FirstName");
            _libraryManager = new LibraryManager(bookRepository, authorRepository, borrowerRepository, borrowedBookRepository);
        }
        #region Book Operations
        public async Task AddNewBook()
        {
            Console.Write("Enter the title: ");
            string newTitle = Console.ReadLine();

            Console.Write("Enter the publication year: ");
            int newPublicationYear = Convert.ToInt32(Console.ReadLine());

            Console.Write("Is available (true/false): ");
            bool newIsAvailable = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Enter the Author First Name : ");
            string firstName = Console.ReadLine();

            Console.Write("Enter the Author Last Name : ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Author Date of Birth (DD/MM/YYY) : ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

            Book newBook = new Book
            {
                Title = newTitle,
                PublicationYear = newPublicationYear,
                IsAvailable = newIsAvailable,
                Author = new Author
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth
                }
            };
            await _libraryManager.AddBookAsync(newBook);
            Colours.Success();
            Console.WriteLine("\nNew book added Successfully.\n");
            Colours.Normal();
        }

        public async Task DisplayAllBooks()
        {
            List<Book> books = await _libraryManager.GetAllBooksAsync();
            Console.WriteLine($"S.No : Title - PublicationYear - Author - Available");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName} - {book.PublicationYear} - {book.IsAvailable}");
            }
        }

        public async Task UpdateBook()
        {
            Console.Write("Enter the Title of the book to update: ");
            string Title = Console.ReadLine();
            Book bookToUpdate = await _libraryManager.GetBookByTitleAsync(Title);
            if (bookToUpdate != null)
            {
                // Set properties for updating the book
                Console.Write("Enter the new title: ");
                string newTitle = Console.ReadLine();
                bookToUpdate.Title = newTitle;

                Console.Write("Enter the new publication year: ");
                int newPublicationYear = Convert.ToInt32(Console.ReadLine());
                bookToUpdate.PublicationYear = newPublicationYear;

                Console.Write("Is the book available? (true/false): ");
                bool newIsAvailable = Convert.ToBoolean(Console.ReadLine());
                bookToUpdate.IsAvailable = newIsAvailable;
                await _libraryManager.UpdateBookAsync(bookToUpdate);
                Colours.Success();
                Console.WriteLine("\nBook updated Successfully.\n");
                Colours.Normal();
            }
            else
            {
                Colours.Error();
                Console.WriteLine("\nBook not found!!!.\n");
                Colours.Normal();
            }
        }

        public async Task DeleteBook()
        {
            Console.Write("Enter the Title of the book to delete: ");
            string Title = Console.ReadLine();
            bool deleteResult = await _libraryManager.DeleteBookAsync(Title);

            if (deleteResult)
            {
                Colours.Success();
                Console.WriteLine("\nBook deleted Successfully.\n");
                Colours.Normal();
            }
            else
            {
                Colours.Error();
                Console.WriteLine("\nBook not found !!!.\n");
                Colours.Normal();
            }
        }
        #endregion Book Operations

        #region Author Operations
        public async Task DisplayAllAuthors()
        {
            List<Author> authors = await _libraryManager.GetAllAuthorsAsync();
            foreach (var author in authors)
            {
                Console.WriteLine($"{author.FirstName} {author.LastName}");
            }
        }

        public async Task AddAuthor()
        {
            Author newAuthor = new Author();
            Console.Write("Enter the Author First Name : ");
            newAuthor.FirstName = Console.ReadLine();

            Console.Write("Enter the Author First Name : ");
            newAuthor.LastName = Console.ReadLine();

            Console.Write("Enter Author Date of Birth : ");
            newAuthor.DateOfBirth = Convert.ToDateTime(Console.ReadLine());

            await _libraryManager.AddAuthorAsync(newAuthor);
            Colours.Success();
            Console.WriteLine("\nAuthor added Successfully.\n");
            Colours.Normal();
        }

        public async Task UpdateAuthor()
        {
            Console.Write("Enter the first name of the author to update: ");
            string updateAuthorName = Console.ReadLine()!;
            Author authorToUpdate = await _libraryManager.GetAuthorByFirstName(updateAuthorName);

            if (authorToUpdate != null)
            {
                Colours.Success();
                Console.WriteLine("\nAuthor found. Enter the new information:\n");
                Colours.Normal();

                Console.Write("Enter the new first name: ");
                string newFirstName = Console.ReadLine();
                authorToUpdate.FirstName = newFirstName;

                Console.Write("Enter the new last name: ");
                string newLastName = Console.ReadLine();
                authorToUpdate.LastName = newLastName;

                Console.Write("Enter the new date of birth (YYYY-MM-DD): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime newDateOfBirth))
                {
                    authorToUpdate.DateOfBirth = newDateOfBirth;

                    bool updateResult = await _libraryManager.UpdateAuthorAsync(authorToUpdate);

                    if (updateResult)
                    {
                        Colours.Success();
                        Console.WriteLine("\nAuthor updated Successfully.\n");
                        Colours.Normal();
                    }
                    else
                    {
                        Colours.Error();
                        Console.WriteLine("\nFailed to update author!!!.\n");
                        Colours.Normal();
                    }
                }
                else
                {
                    Colours.Error();
                    Console.WriteLine("\nInvalid date format!!!.\n");
                    Colours.Normal();
                }
            }
            else
            {
                Colours.Error();
                Console.WriteLine("\nAuthor not found.\n");
                Colours.Normal();
            }

        }

        public async Task DeleteAuthor()
        {
            Console.Write("Enter the first name of the author to delete: ");
            string deleteAuthorName = Console.ReadLine();
            bool deleteAuthorResult = await _libraryManager.DeleteAuthorByFirstNameAsync(deleteAuthorName);

            if (deleteAuthorResult)
            {
                Colours.Success();
                Console.WriteLine("\nAuthor deleted Successfully.\n");
                Colours.Normal();
            }
            else
            {
                Colours.Error();
                Console.WriteLine("\nAuthor not found!!!.\n");
                Colours.Normal();
            }
        }
        #endregion Author Operations

        #region Borrower operations
        public async Task AddBorrower()
        {
            // Create a new Borrower instance
            Borrower newBorrower = new Borrower();

            // Prompt the user to provide information for the new borrower
            Console.Write("Enter the first name of the borrower: ");
            newBorrower.FirstName = Console.ReadLine();

            Console.Write("Enter the last name of the borrower: ");
            newBorrower.LastName = Console.ReadLine();

            Console.Write("Enter the email of the borrower: ");
            newBorrower.Email = Console.ReadLine();

            Console.Write("Enter the phone number of the borrower: ");
            newBorrower.PhoneNumber = Console.ReadLine();

            // Add the new borrower to the repository
            await _libraryManager.AddBorrowerAsync(newBorrower);
            Colours.Success();
            Console.WriteLine("\nBorrower added Successfully.\n");
            Colours.Normal();
        }

        public async Task UpdateBorrower()
        {
            // Prompt the user to enter the full name of the borrower they want to update
            Console.Write("Enter the First name of the borrower to update: ");
            string updateBorrowerName = Console.ReadLine();

            // Retrieve the borrower from the repository based on the provided full name
            Borrower borrowerToUpdate = await _libraryManager.GetBorrowerByFirstNameAsync(updateBorrowerName);

            if (borrowerToUpdate != null)
            {
                Console.WriteLine("Borrower found. Enter the new information:");

                Console.Write("Enter the new first name: ");
                borrowerToUpdate.FirstName = Console.ReadLine();

                Console.Write("Enter the new last name: ");
                borrowerToUpdate.LastName = Console.ReadLine();

                Console.Write("Enter the new email: ");
                borrowerToUpdate.Email = Console.ReadLine();

                Console.Write("Enter the new phone number: ");
                borrowerToUpdate.PhoneNumber = Console.ReadLine();

                // Updating the borrower's information in the repository
                await _libraryManager.UpdateBorrowerAsync(borrowerToUpdate);
                Colours.Success();
                Console.WriteLine("\nBorrower updated Successfully.\n");
                Colours.Normal();
            }
            else
            {
                Colours.Error();
                Console.WriteLine("Borrower not found.");
                Colours.Normal();
            }

        }

        public async Task DeleteBorrower()
        {
            Console.Write("Enter the first name of the borrower to delete : ");
            string deleteBorrowerName = Console.ReadLine();
            bool deleteBorrowerResult = await _libraryManager.DeleteBorrowerByFirstNameAsync(deleteBorrowerName);

            if (deleteBorrowerResult)
            {
                Colours.Success();
                Console.WriteLine("\nBorrower deleted Successfully.\n");
                Colours.Normal();
            }
            else
            {
                Colours.Error();
                Console.WriteLine("\nBorrower not found!!!.\n");
                Colours.Normal();
            }
        }

        public async Task DisplayAllBorrower()
        {
            List<Borrower> borrowers = await _libraryManager.GetAllBorrowersAsync();
            foreach (var borrower in borrowers)
            {
                Console.WriteLine($"{borrower.FirstName} {borrower.LastName} - {borrower.Email}");
            }
        }
        #endregion Borrower operations

        #region Miscellaneous Methods
        public async Task RegisterBookToBorrower()
        {
            Console.Write("Enter the Title of the book to register: ");
            string title = Console.ReadLine()!;
            Console.Write("Enter the first name of the borrower: ");
            string borrowerFirstName = Console.ReadLine()!;

            bool registrationResult = await _libraryManager.RegisterBookToBorrowerAsync(title, borrowerFirstName);

            if (registrationResult)
            {
                Colours.Success();
                Console.WriteLine("\nBook registered to borrower Successfully.\n");
                Colours.Normal();
            }
            else
            {
                Colours.Error();
                Console.WriteLine("\nBook or borrower not found!!!.\n");
                Colours.Normal();
            }
        }

        public async Task DisplayBorrowedBook()
        {
            List<BorrowedBook> borrowedBooks = await _libraryManager.GetAllBorrowedBooksAsync();
            foreach (var borrowedBook in borrowedBooks)
            {
                Console.WriteLine($"Book: {borrowedBook.Book.Title}, Borrower: {borrowedBook.Borrower.FirstName} {borrowedBook.Borrower.LastName}");
            }
        }

        public async Task SearchBooks()
        {
            Console.Write("Enter the keyword to search for: \n");
            string searchKeyword = Console.ReadLine();
            List<Book> searchResults = await _libraryManager.SearchBooksAsync(searchKeyword);
            if(searchResults == null)
            {
                Colours.Error();
                Console.WriteLine("\nNo book is available with thid keyword\n");
                Colours.Normal();
            }

            foreach (var result in searchResults)
            {
                Colours.Success();
                Console.WriteLine($"{result.Title} - {result.Author.FirstName} {result.Author.LastName}");
                Colours.Normal();
            }
        }

        public async Task SearchBookByStatus()
        {
            Console.WriteLine("Select book status (available/borrowed): \n");
            string statusChoice = Console.ReadLine();
            bool isAvailable = statusChoice.ToLower() == "available";
            if(!isAvailable)
            {
                Colours.Error();
                Console.WriteLine("\nNo book is available for borrow\n");
                Colours.Normal();
            }

            List<Book> filteredBooks = await _libraryManager.FilterBooksByStatusAsync(isAvailable);
            foreach (var book in filteredBooks)
            {
                Colours.Success();
                Console.WriteLine($"{book.Title} - {book.Author.FirstName} {book.Author.LastName}");
                Colours.Normal();
            }
        }
        #endregion Miscellaneous Methods

    }
}
