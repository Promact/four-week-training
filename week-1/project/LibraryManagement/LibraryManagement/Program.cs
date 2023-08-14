using System.Text.RegularExpressions;

namespace LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize collections for books, authors, and borrowers
            List<Book> books = new List<Book>();
            List<Author> authors = new List<Author>();
            List<Borrower> borrowers = new List<Borrower>();
            List<BorrowedBook> borrowedbooks = new List<BorrowedBook>();

            // Main program loop
            while (true)
            {
                DisplayMenu();

                int choice;
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    // Add cases for each menu option
                    case 1:
                        // Add a book
                        Book.AddBook(books);
                        break;
                    
                    case 2:
                        //Update a book
                        Book.UpdateBook(books);
                        break; 

                    case 3:
                        //Delete a book
                        Book.DeleteBook(books);
                        break; 

                    case 4: 
                        //List all books
                        Book.ListAllBooks(books);
                        break; 

                    case 5:
                        // Add an author 
                        Author.AddAuthor(authors);
                        break; 

                    case 6: 
                        // Update an author
                        Author.UpdateAuthor(authors);
                        break; 

                    case 7:
                        // Delete an author 
                        Author.DeleteAuthor(authors);
                        break;

                    case 8:  
                        // List all authors
                        Author.ListAllAuthors(authors);
                        break; 

                    case 9:
                        // Add a borrower
                        Borrower.AddBorrower(borrowers);
                        break; 

                    case 10:
                        // Update a borrower
                        Borrower.UpdateBorrower(borrowers);
                        break; 

                    case 11:
                        // Delete a borrower
                        Borrower.DeleteBorrower(borrowers);
                        break;

                     case 12:
                        // List all borrowers
                        Borrower.ListAllBorrowers(borrowers);
                        break;

                    case 13:
                        // Register a book to borrower
                        BorrowedBook.RegisterBookToBorrower(books, borrowers);
                        break;

                     case 14:
                        // Display borrowed books
                        BorrowedBook.DisplayBorrowedBooks(books);
                        break;

                     case 15:
                        //Search books
                        BorrowedBook.SearchBooks(books);
                        break;

                    case 16:
                        // Filter books by status
                        BorrowedBook.FilterBooksByStatus(books);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            // Display the menu options
            Console.WriteLine("Welcome to the Library Management System!\n");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Update a book");
            Console.WriteLine("3. Delete a book");
            Console.WriteLine("4. List all books");
            // ...Add Other options here
            Console.WriteLine("5. Add an author");
            Console.WriteLine("6. Update an author");
            Console.WriteLine("7. Delete an author");
            Console.WriteLine("8. List all authors");
            Console.WriteLine("9. Add a borrower");
            Console.WriteLine("10. Update a borrower");
            Console.WriteLine("11. Delete a borrower");
            Console.WriteLine("12. List all borrowers");
            Console.WriteLine("13. Register a book to a borrower");
            Console.WriteLine("14. Display author books");
            Console.WriteLine("15. Search books");
            Console.WriteLine("16. Filter books by status");
            Console.WriteLine("\nEnter the number corresponding to the action you'd like to perform:");
        }
    }

    // Class definitions
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }

        public static void AddBook(List<Book> books)
        {
            Book newBook = new Book();

            Console.Write("Enter the book title: ");
            newBook.Title = Console.ReadLine();

            Console.Write("Enter author first name: ");
            string authorFirstName = Console.ReadLine();

            Console.Write("Enter author last name: ");
            string authorLastName = Console.ReadLine();

            Console.Write("Enter the publication year: ");
            if (int.TryParse(Console.ReadLine(), out int publicationYear))
            {
                newBook.PublicationYear = publicationYear;
            }
            else
            {
                Console.WriteLine("Invalid input for publication year.");
                return;
            }

            newBook.IsAvailable = true;
            newBook.Id = books.Count + 1;
             
            books.Add(newBook);
            Console.WriteLine("Book added successfully!");
        }
       public static void UpdateBook(List<Book> books)
        {
            Console.Write("Enter the ID of the book to update: ");
            if (int.TryParse(Console.ReadLine(), out int BookId))
            {
                Book bookToUpdate = books.FirstOrDefault(book => book.Id == BookId);
                if (bookToUpdate != null)
                {
                    Console.Write("Enter the new title: ");
                    bookToUpdate.Title = Console.ReadLine();

                    Console.Write("Enter the new publication year: ");
                    if (int.TryParse(Console.ReadLine(), out int publicationYear))
                    {
                        bookToUpdate.PublicationYear = publicationYear;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for publication year. Book not updated.");
                        return;
                    }

                    Console.WriteLine("Book updated successfully!");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for book ID.");
            }
        }

        public static void DeleteBook(List<Book> books)
        {
            Console.Write("Enter the ID of the book to delete: ");
            if (int.TryParse(Console.ReadLine(), out int bookId))
            {
                Book bookToDelete = books.FirstOrDefault(book => book.Id == bookId);
                if (bookToDelete != null)
                {
                    books.Remove(bookToDelete);
                    Console.WriteLine("Book deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for book ID.");
            }
        }

        public static void ListAllBooks(List<Book> books)
        {
            Console.WriteLine("\nList of Books:");
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}, Title: {book.Title}"+
                                  $"Publication Year: {book.PublicationYear}");
            }
        }
    }

    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Id { get; set; }

        public static void AddAuthor(List<Author> authors)
        {
            Author newAuthor = new Author();

            Console.Write("Enter the author's first name: ");
            newAuthor.FirstName = Console.ReadLine();

            Console.Write("Enter the author's last name: ");
            newAuthor.LastName = Console.ReadLine();

            Console.Write("Enter the author's date of birth (yyyy-mm-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
            {
                newAuthor.DateOfBirth = dateOfBirth;
            }
            else
            {
                Console.WriteLine("Invalid input for date of birth.");
                return;
            }

            newAuthor.Id = authors.Count + 1; // Assign a unique ID

            authors.Add(newAuthor);
            Console.WriteLine("Author added successfully!");
        }

        public static void UpdateAuthor(List<Author> authors)
        {
            Console.Write("Enter the ID of the author to update: ");
            int authorId;
            if (int.TryParse(Console.ReadLine(), out authorId))
            {
                Author authorToUpdate = authors.FirstOrDefault(auth => auth.Id == authorId);
                if (authorToUpdate != null)
                {
                    // Update author details
                    Console.Write("Enter the new first name: ");
                    authorToUpdate.FirstName = Console.ReadLine();

                    Console.Write("Enter the new last name: ");
                    authorToUpdate.LastName = Console.ReadLine();

                    Console.Write("Enter the new date of birth (yyyy-mm-dd): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
                    {
                        authorToUpdate.DateOfBirth = dateOfBirth;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for date of birth. Author not updated.");
                        return;
                    }

                    Console.WriteLine("Author updated successfully!");
                }
                else
                {
                    Console.WriteLine("Author not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for author ID.");
            }
        }

        public static void DeleteAuthor(List<Author> authors)
        {
            Console.Write("Enter the ID of the author to delete: ");
            int authorId;
            if (int.TryParse(Console.ReadLine(), out authorId))
            {
                Author authorToDelete = authors.FirstOrDefault(auth => auth.Id == authorId);
                if (authorToDelete != null)
                {
                    authors.Remove(authorToDelete);
                    Console.WriteLine("Author deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Author not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for author ID.");
            }
        }

       public static void ListAllAuthors(List<Author> authors)
        {
            Console.WriteLine("List of all authors:");
            foreach (var author in authors)
            {
                Console.WriteLine($"ID: {author.Id}, Name: {author.FirstName} {author.LastName}, Date of Birth: {author.DateOfBirth}");
            }
        }
    }

    public class Borrower
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        
        public int Id { get; set; }

        public static void AddBorrower(List<Borrower> borrowers)
        {
            Borrower newBorrower = new Borrower();

            Console.Write("Enter the borrower's first name: ");
            newBorrower.FirstName = Console.ReadLine();

            Console.Write("Enter the borrower's last name: ");
            newBorrower.LastName = Console.ReadLine();

            Console.Write("Enter the borrower's email: ");
            string email = Console.ReadLine();


            static bool IsValidEmail(string email)
            {
                // This regular expression pattern checks for a basic valid email format
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(email, pattern);
            }

            if (IsValidEmail(email))
            {
                newBorrower.Email = email;
            }
            else
            {
                Console.WriteLine("Invalid email format.");
                return;
            }

            newBorrower.Email = Console.ReadLine();

            Console.Write("Enter the borrower's phone number: ");
            newBorrower.PhoneNumber = Console.ReadLine();

            string newPhoneNumber = Console.ReadLine();
            newBorrower.PhoneNumber = newPhoneNumber;

            newBorrower.Id = borrowers.Count + 1; // Assign a unique ID

            borrowers.Add(newBorrower);
            Console.WriteLine("Borrower added successfully!");
        }

        public static void UpdateBorrower(List<Borrower> borrowers)
        {
            Console.Write("Enter the ID of the borrower to update: ");
            int borrowerId;
            if (int.TryParse(Console.ReadLine(), out borrowerId))
            {
                Borrower borrowerToUpdate = borrowers.FirstOrDefault(borrow => borrow.Id == borrowerId);
                if (borrowerToUpdate != null)
                {
                    // Update borrower details
                    Console.Write("Enter the new first name: ");
                    borrowerToUpdate.FirstName = Console.ReadLine();

                    Console.Write("Enter the new last name: ");
                    borrowerToUpdate.LastName = Console.ReadLine();

                    Console.Write("Enter the new email: ");
                    borrowerToUpdate.Email = Console.ReadLine();

                    Console.Write("Enter the new phone number: ");
                    borrowerToUpdate.PhoneNumber = Console.ReadLine();

                    Console.WriteLine("Borrower updated successfully!");
                }
                else
                {
                    Console.WriteLine("Borrower not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for borrower ID.");
            }
        }

        public static void DeleteBorrower(List<Borrower> borrowers)
        {
            Console.Write("Enter the ID of the borrower to delete: ");
            int borrowerId;
            if (int.TryParse(Console.ReadLine(), out borrowerId))
            {
                Borrower borrowerToDelete = borrowers.FirstOrDefault(borrow => borrow.Id == borrowerId);
                if (borrowerToDelete != null)
                {
                    borrowers.Remove(borrowerToDelete);
                    Console.WriteLine("Borrower deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Borrower not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for borrower ID.");
            }
        }

        public static void ListAllBorrowers(List<Borrower> borrowers)
        {
            Console.WriteLine("List of all borrowers:");
            foreach (var borrower in borrowers)
            {
                Console.WriteLine($"ID: {borrower.Id}, Name: {borrower.FirstName} {borrower.LastName}, Email: {borrower.Email}, Phone: {borrower.PhoneNumber}");
            }
        }
    }

    public class BorrowedBook
    {
        public Book Book { get; set; }
        public Borrower Borrower { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }

        public static void RegisterBookToBorrower(List<Book> books, List<Borrower> borrowers)
        {
            Console.WriteLine("Select a book to register to a borrower:");
            static void ListAllBooks(List<Book> books)
            {
                Console.WriteLine("List of all books:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Publication Year: {book.PublicationYear}");
                }
            }

            static void ListAllBorrowers(List<Borrower> borrowers)
            {
                Console.WriteLine("List of all borrowers:");
                foreach (var borrower in borrowers)
                {
                    Console.WriteLine($"ID: {borrower.Id}, Name: {borrower.FirstName} {borrower.LastName}, Email: {borrower.Email}, Phone: {borrower.PhoneNumber}");
                }
            }
            ListAllBooks(books);

            int bookId;
            if (int.TryParse(Console.ReadLine(), out bookId))
            {
                Book selectedBook = books.FirstOrDefault(b => b.Id == bookId);
                if (selectedBook != null)
                {
                    Console.WriteLine("Select a borrower:");
                    ListAllBorrowers(borrowers);

                    int borrowerId;
                    if (int.TryParse(Console.ReadLine(), out borrowerId))
                    {
                        Borrower selectedBorrower = borrowers.FirstOrDefault(b => b.Id == borrowerId);
                        if (selectedBorrower != null)
                        {
                            selectedBook.IsAvailable = false;
                            Console.WriteLine($"Book '{selectedBook.Title}' registered to borrower '{selectedBorrower.FirstName} {selectedBorrower.LastName}'.");
                        }
                        else
                        {
                            Console.WriteLine("Borrower not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for borrower ID.");
                    }
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for book ID.");
            }
        }

        public static void DisplayBorrowedBooks(List<Book> books)
        {
            Console.WriteLine("List of borrowed books:");
            foreach (var book in books)
            {
                if (!book.IsAvailable)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}");
                }
            }
        }

        public static void SearchBooks(List<Book> books)
        {
            Console.Write("Enter a search keyword: ");
            string keyword = Console.ReadLine();

            List<Book> searchResults = books.Where(x=> x.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

            if (searchResults.Count > 0)
            {
                Console.WriteLine("Search results:");
                foreach (var book in searchResults)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}");
                }
            }
            else
            {
                Console.WriteLine("No results found.");
            }
        }

        public static void FilterBooksByStatus(List<Book> books)
        {
            Console.WriteLine("Select a status to filter books:");
            Console.WriteLine("1. Available");
            Console.WriteLine("2. Borrowed");

            int statusChoice;
            if (int.TryParse(Console.ReadLine(), out statusChoice))
            {
                bool isAvailable = statusChoice == 1;

                List<Book> filteredBooks = books.Where(b => b.IsAvailable == isAvailable).ToList();

                Console.WriteLine($"List of {(isAvailable ? "available" : "borrowed")} books:");
                foreach (var book in filteredBooks)
                {
                    Console.WriteLine($"ID: {book.Id}, Title: {book.Title}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}