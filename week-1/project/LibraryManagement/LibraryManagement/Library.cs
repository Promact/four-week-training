using LibraryManagement.Models;
using LibraryManagement.Repository.IRepository;

namespace LibraryManagement
{
    public class Library
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBorrowerRepository _borrowerRepository;
        private readonly IBorrowedBookRepository _borrowedBookRepository;

        public Library(IBookRepository bookRepository, IAuthorRepository authorRepository,
            IBorrowerRepository borrowerRepository, IBorrowedBookRepository borrowedBookRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _borrowerRepository = borrowerRepository;
            _borrowedBookRepository = borrowedBookRepository;
        }

        public async Task AddBookAsync()
        {
            try
            {
                Console.WriteLine("Enter Book's Title: ");
                string title = Console.ReadLine();
                Console.WriteLine("Enter Author's First Name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Author's Last Name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Enter Author's DOB (in MM/DD/YYYY): ");
                DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter book's Publication Year: ");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine("Book's availablity: ");
                bool isAvailable = bool.Parse(Console.ReadLine());

                Author author = new Author
                {
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth.Date
                };
                Book book = new Book
                {
                    Title = title,
                    Author = author,
                    PublicationYear = year,
                    IsAvailable = isAvailable
                };

                _bookRepository.Add(book);
                _authorRepository.Add(author);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book added successfully: ");
                Console.ResetColor();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateBookAsync(int index)
        {
            int count = _bookRepository.GetAll().Count();

            if (index >= 0 && index < count)
            {
                Book updateBook = _bookRepository.GetAll()[index];

                Console.WriteLine("Enter Updated book's title: ");
                string updatedTitle = Console.ReadLine();
                updateBook.Title = updatedTitle;

                _bookRepository.Update(index, updateBook);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book updated successfully: ");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Invalid index: ");
                return;
            }
        }

        public async Task DeleteBookAsync(int index)
        {
            int count = _bookRepository.GetAll().Count();

            if (index >= 0 && index < count)
            {
                _bookRepository.Delete(index);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book deleted successfully: ");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"There is no any book of the given index: {index}\n");
                Console.ResetColor();
            }
        }

        public async Task ListAllBookAsync()
        {
            Console.WriteLine("All Books:");
            var list = _bookRepository.GetAll();
            if(list != null)
            {
                foreach (var item in list)
                {
                    Console.WriteLine($"Title: {item.Title}, " +
                        $"\nAuthor: {item.Author.FirstName} {item.Author.LastName}, " +
                        $"\nAuthor's DOB: {item.Author.DateOfBirth}, " +
                        $"\nPublication Year: {item.PublicationYear}, " +
                        $"\nIs Available: {item.IsAvailable} \n");
                }
            }
            else
            {
                Console.WriteLine("Empty Book list.");
            }
        }

        public async Task AddAuthorAsync()
        {
            Console.WriteLine("Enter Author's First Name: ");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter Author's Last Name: ");
            string lName = Console.ReadLine();
            Console.WriteLine("Enter Author's DOB (in MM/DD/YYYY): ");
            DateTime dob = DateTime.Parse(Console.ReadLine());

            Author newAuthor = new Author
            {
                FirstName = fName,
                LastName = lName,
                DateOfBirth = dob.Date
            };

            _authorRepository.Add(newAuthor);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Author added successfully: ");
            Console.ResetColor();
        }

        public async Task UpdateAuthorAsync(int index)
        {
            int count = _authorRepository.GetAll().Count();

            if (index >= 0 && index < count)
            {
                Author updateAuthor = _authorRepository.GetAll()[index];

                Console.WriteLine("Update author's FirstName: ");
                string updatedName = Console.ReadLine();
                updateAuthor.FirstName = updatedName;

                _authorRepository.Update(index, updateAuthor);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Author updated successfully: ");
                Console.ResetColor();
            }
        }

        public async Task DeleteAuthorAsync(int index)
        {
            int count = _authorRepository.GetAll().Count();

            if (index >= 0 && index < count)
            {
                _authorRepository.Delete(index);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Author deleted successfully: ");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"There is no any author of the given index: {index}\n");
                Console.ResetColor();
            }
        }

        public async Task ListAllAuthorAsync()
        {
            Console.WriteLine("All Author:");

            var list = _authorRepository.GetAll();
            if (list != null)
            {
                foreach (var people in list)
                {
                    Console.WriteLine($"Author Name: {people.FirstName} {people.LastName}, " +
                        $"\nAuthor's DOB: {people.DateOfBirth}");
                }
            }
            else
            {
                Console.WriteLine("No Author available.");
            }
        }

        public async Task AddBorrowerAsync()
        {
            try
            {
                Console.WriteLine("Enter Borrower's First Name: ");
                string borrowerFirstName = Console.ReadLine();
                Console.WriteLine("Enter Borrower's Last Name: ");
                string borrowerLastName = Console.ReadLine();
                Console.WriteLine("Enter Borrower's Email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Borrower's Phone Number: ");
                long phoneNumber = long.Parse(Console.ReadLine());

                Borrower borrower = new Borrower()
                {
                    FirstName = borrowerFirstName,
                    LastName = borrowerLastName,
                    Email = email,
                    PhoneNumber = phoneNumber
                };

                _borrowerRepository.Add(borrower);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Borrower added successfully: ");
                Console.ResetColor();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateBorrowerAsync(int index)
        {
            int count = _borrowerRepository.GetAll().Count();

            if (index >= 0 && index < count)
            {
                Borrower updateBorrower = _borrowerRepository.GetAll()[index];

                Console.WriteLine("Update borrower's email: ");
                string updatedEmail = Console.ReadLine();
                updateBorrower.Email = updatedEmail;

                _borrowerRepository.Update(index, updateBorrower);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Borrower updated successfully: ");
                Console.ResetColor();
            }
        }

        public async Task DeleteBorrowerAsync(int index)
        {
            int count = _authorRepository.GetAll().Count();

            if (index >= 0 && index < count)
            {
                _borrowerRepository.Delete(index);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Borrower deleted successfully: ");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"There is no any borrower of the given index: {index}\n");
                Console.ResetColor();
            }
        }

        public async Task ListAllBorrowerAsync()
        {
            Console.WriteLine("All Borrower:");
            var list = _borrowerRepository.GetAll();

            if(list != null)
            {
                foreach (var people in list)
                {
                    Console.WriteLine($"Borrower Name: {people.FirstName} {people.LastName}, " +
                        $"\nBorrower's Email: {people.Email}, " +
                        $"\nBorrower's Phone Number: {people.PhoneNumber} \n");
                }
            }
            else
            {
                Console.WriteLine("Empty brorrower list.");
            }
        }

        public async Task RegisterBoookToBorrowerAsync(int bookIndex, int borrowerIndex)
        {
            try
            {
                var books = _bookRepository.GetAll()[bookIndex];
                var borrower = _borrowerRepository.GetAll()[borrowerIndex];

                BorrowedBook borrowedBook = new BorrowedBook()
                {
                    Book = books,
                    Borrower = borrower,
                    BorrowDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(15),
                };

                Book book = new Book();


                _borrowedBookRepository.Add(borrowedBook);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book registered to borrower successfully: ");

                book.IsAvailable = false;
                _bookRepository.Update(bookIndex, book);
                Console.ResetColor();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task DisplayBorrowedBookAsync()
        {
            Console.WriteLine("Borrowed Books:");
            var list = _borrowedBookRepository.GetAll();
            if(list != null)
            {
                foreach (var books in list)
                {
                    Console.WriteLine($"Books: \nTitle: {books.Book.Title}, " +
                        $"\nBorrower Name: {books.Borrower.FirstName} {books.Borrower.LastName}, " +
                        $"\nBorrower's Email: {books.Borrower.Email}, " +
                        $"\nBorrower's Phone Number: {books.Borrower.PhoneNumber}, " +
                        $"\nBorrow Date: {books.BorrowDate}, " +
                        $"\nDueDate: {books.DueDate} \n");
                }
            }
            else
            {
                Console.WriteLine("Empty Borrowed Books list.");
            }
        }

        public async Task SearchByAsync(string searchString)
        {
            var result = _bookRepository.GetAll().Where(book => book.Title.ToLower().Contains(searchString)).ToList();

            if(result != null)
            {
                foreach (var book in result)
                {
                    Console.WriteLine($"Book Title: {book.Title}, " +
                                      $"\nAuthor: {book.Author.FirstName} {book.Author.LastName}, " +
                                      $"\nPublication Year: {book.PublicationYear}," +
                                      $"\nIs Available: {book.IsAvailable} ");
                }
            }
            else
            {
                Console.WriteLine("No Books Found.");
            }
        }

        public async Task FilterByStatus(bool status)
        {
            var result = _bookRepository.GetAll().Where(
                book => book.IsAvailable == status);

            if (result.Count() != 0)
            {
                Console.WriteLine("Available Books are: ");
                foreach (var book in result)
                {
                    Console.WriteLine($"Title: {book.Title}," +
                        $"\nAuthor: {book.Author.FirstName} {book.Author.LastName}," +
                        $"\nPublication Year: {book.PublicationYear}, " +
                        $"\nIs Available: {book.IsAvailable} ");
                }
            }
            else
            {
                Console.WriteLine("Book is not available.");
            }
        }
    }
}
