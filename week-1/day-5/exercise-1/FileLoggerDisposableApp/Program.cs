using System;
using System.Collections.Generic;

namespace LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            List<Author> authors = new List<Author>();
            List<Borrower> borrowers = new List<Borrower>();
            List<BorrowedBook> borrowedBooks = new List<BorrowedBook>();

            while (true)
            {
                DisplayMenu();

                int choice;
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        AddBook(books, authors);
                        break;
                    case 2:
                        // Update a book
                        break;
                    case 3:
                        // Delete a book
                        break;
                    case 4:
                        ListBooks(books);
                        break;
                    case 5:
                        AddAuthor(authors);
                        break;
                    case 6:
                        // Update an author
                        break;
                    case 7:
                        // Delete an author
                        break;
                    case 8:
                        ListAuthors(authors);
                        break;
                    case 9:
                        AddBorrower(borrowers);
                        break;
                    case 10:
                        // Update a borrower
                        break;
                    case 11:
                        // Delete a borrower
                        break;
                    case 12:
                        ListBorrowers(borrowers);
                        break;
                    case 13:
                        RegisterBookToBorrower(books, borrowers, borrowedBooks);
                        break;
                    case 14:
                        DisplayBorrowedBooks(borrowedBooks);
                        break;
                    case 15:
                        SearchBooks(books);
                        break;
                    case 16:
                        FilterBooksByStatus(books);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Welcome to the Library Management System!\n");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Update a book");
            Console.WriteLine("3. Delete a book");
            Console.WriteLine("4. List all books");
            Console.WriteLine("5. Add an author");
            Console.WriteLine("6. Update an author");
            Console.WriteLine("7. Delete an author");
            Console.WriteLine("8. List all authors");
            Console.WriteLine("9. Add a borrower");
            Console.WriteLine("10. Update a borrower");
            Console.WriteLine("11. Delete a borrower");
            Console.WriteLine("12. List all borrowers");
            Console.WriteLine("13. Register a book to a borrower");
            Console.WriteLine("14. Display borrowed books");
            Console.WriteLine("15. Search books");
            Console.WriteLine("16. Filter books by status");
            Console.WriteLine("\nEnter the number corresponding to the action you'd like to perform:");
        }

        static void AddBook(List<Book> books, List<Author> authors)
        {
            Console.Write("Enter the title of the book: ");
            string title = Console.ReadLine();

            Console.Write("Enter the index of the author: ");
            int authorIndex;
            int.TryParse(Console.ReadLine(), out authorIndex);

            Console.Write("Enter the publication year: ");
            int publicationYear;
            int.TryParse(Console.ReadLine(), out publicationYear);

            bool isAvailable = true;

            if (authorIndex >= 0 && authorIndex < authors.Count)
            {
                Author author = authors[authorIndex];
                Book newBook = new Book
                {
                    Title = title,
                    Author = author,
                    PublicationYear = publicationYear,
                    IsAvailable = isAvailable
                };

                books.Add(newBook);
                Console.WriteLine("Book added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid author index.");
            }
        }

        static void ListBooks(List<Book> books)
        {
            Console.WriteLine("List of all books:\n");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author.FirstName} {book.Author.LastName}");
                Console.WriteLine($"Publication Year: {book.PublicationYear}");
                Console.WriteLine($"Status: {(book.IsAvailable ? "Available" : "Borrowed")}");
                Console.WriteLine();
            }
        }

        static void AddAuthor(List<Author> authors)
        {
            Console.Write("Enter the first name of the author: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter the last name of the author: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter the date of birth (yyyy-MM-dd) of the author: ");
            DateTime dateOfBirth;
            DateTime.TryParse(Console.ReadLine(), out dateOfBirth);

            Author newAuthor = new Author
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };

            authors.Add(newAuthor);
            Console.WriteLine("Author added successfully!");
        }

        static void ListAuthors(List<Author> authors)
        {
            Console.WriteLine("List of all authors:\n");
            foreach (var author in authors)
            {
                Console.WriteLine($"Author: {author.FirstName} {author.LastName}");
                Console.WriteLine($"Date of Birth: {author.DateOfBirth.ToString("yyyy-MM-dd")}");
                Console.WriteLine();
            }
        }

        static void AddBorrower(List<Borrower> borrowers)
        {
            Console.Write("Enter the first name of the borrower: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter the last name of the borrower: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter the email of the borrower: ");
            string email = Console.ReadLine();

            Console.Write("Enter the phone number of the borrower: ");
            string phoneNumber = Console.ReadLine();

            Borrower newBorrower = new Borrower
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            borrowers.Add(newBorrower);
            Console.WriteLine("Borrower added successfully!");
        }

        static void ListBorrowers(List<Borrower> borrowers)
        {
            Console.WriteLine("List of all borrowers:\n");
            foreach (var borrower in borrowers)
            {
                Console.WriteLine($"Borrower: {borrower.FirstName} {borrower.LastName}");
                Console.WriteLine($"Email: {borrower.Email}");
                Console.WriteLine($"Phone Number: {borrower.PhoneNumber}");
                Console.WriteLine();
            }
        }

        static void RegisterBookToBorrower(List<Book> books, List<Borrower> borrowers, List<BorrowedBook> borrowedBooks)
        {
            Console.Write("Enter the index of the book to register: ");
            int bookIndex;
            int.TryParse(Console.ReadLine(), out bookIndex);

            Console.Write("Enter the index of the borrower: ");
            int borrowerIndex;
            int.TryParse(Console.ReadLine(), out borrowerIndex);

            Console.Write("Enter the due date (yyyy-MM-dd) for the book: ");
            DateTime dueDate;
            DateTime.TryParse(Console.ReadLine(), out dueDate);

            if (bookIndex >= 0 && bookIndex < books.Count && borrowerIndex >= 0 && borrowerIndex < borrowers.Count)
            {
                Book book = books[bookIndex];
                Borrower borrower = borrowers[borrowerIndex];

                BorrowedBook borrowedBook = new BorrowedBook
                {
                    Book = book,
                    Borrower = borrower,
                    BorrowDate = DateTime.Now,
                    DueDate = dueDate
                };

                borrowedBooks.Add(borrowedBook);
                book.IsAvailable = false;

                Console.WriteLine("Book registered to borrower successfully!");
            }
            else
            {
                Console.WriteLine("Invalid book or borrower index.");
            }
        }

        static void DisplayBorrowedBooks(List<BorrowedBook> borrowedBooks)
        {
            Console.WriteLine("List of borrowed books:\n");
            foreach (var borrowedBook in borrowedBooks)
            {
                Console.WriteLine($"Book: {borrowedBook.Book.Title}");
                Console.WriteLine($"Borrower: {borrowedBook.Borrower.FirstName} {borrowedBook.Borrower.LastName}");
                Console.WriteLine($"Borrow Date: {borrowedBook.BorrowDate.ToString("yyyy-MM-dd")}");
                Console.WriteLine($"Due Date: {borrowedBook.DueDate.ToString("yyyy-MM-dd")}");
                Console.WriteLine();
            }
        }

        static void SearchBooks(List<Book> books)
        {
            Console.Write("Enter a keyword to search for: ");
            string keyword = Console.ReadLine();

            Console.WriteLine($"Search results for '{keyword}':\n");
            foreach (var book in books)
            {
                if (book.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    book.Author.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    book.Author.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine($"Author: {book.Author.FirstName} {book.Author.LastName}");
                    Console.WriteLine($"Publication Year: {book.PublicationYear}");
                    Console.WriteLine($"Status: {(book.IsAvailable ? "Available" : "Borrowed")}");
                    Console.WriteLine();
                }
            }
        }

        static void FilterBooksByStatus(List<Book> books)
        {
            Console.WriteLine("Filter books by status:");
            Console.WriteLine("1. Available");
            Console.WriteLine("2. Borrowed");
            Console.Write("Enter the number corresponding to the status: ");

            int statusChoice;
            int.TryParse(Console.ReadLine(), out statusChoice);

            bool isAvailable = statusChoice == 1;

            Console.WriteLine($"Books {(isAvailable ? "Available" : "Borrowed")}:\n");

            foreach (var book in books)
            {
                if (book.IsAvailable == isAvailable)
                {
                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine($"Author: {book.Author.FirstName} {book.Author.LastName}");
                    Console.WriteLine($"Publication Year: {book.PublicationYear}");
                    Console.WriteLine();
                }
            }
        }
    }

    class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
    }

    class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    class Borrower
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    class BorrowedBook
    {
        public Book Book { get; set; }
        public Borrower Borrower { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}
