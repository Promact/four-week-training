using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagement
{
    internal class Program
    {
    static List<Book> books = new List<Book>();
    static List<Author> authors = new List<Author>();
    static List<Borrower> borrowers = new List<Borrower>();
    // Make a List Of Borrowed Books also
    static List<BorrowedBook> borrowedBooks = new List<BorrowedBook>(); 


        static void Main(string[] args)
        {
            // Initialize collections for books, authors, and borrowers

            // Main program loop
            while (true)
            {
                DisplayMenu();

                int choice;
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        UpdateBook();
                        break;
                    case 3:
                        DeleteBook();
                        break;
                    case 4:
                        ListAllBooks();
                        break;
                    case 5:
                        AddAuthor();
                        break;
                    case 6:
                        AddBorrower();
                        break;
                    case 7:
                        RegisterBookToBorrower();
                        break;
                    case 8:
                        ListAllAuthors();
                        break;
                    case 9:
                        ListAllBorrowers();
                        break;
                    case 10:
                        DisplayAllBorrowedBooks();
                        break;
                    case 11:
                        SearchBooks();
                        break;
                    case 12:
                        FilterBooksByStatus();
                        break;
                    case 0:
                        Console.WriteLine("Exiting the program.");
                        return;
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
            Console.WriteLine("5. Add an author");
            Console.WriteLine("6. Add a borrower");
            Console.WriteLine("7. Register book to borrower");
            Console.WriteLine("8. List all authors");
            Console.WriteLine("9. List all borrowers");
            Console.WriteLine("10. Display all borrowed books");
            Console.WriteLine("11. Search books");
            Console.WriteLine("16. Filter books by status");
            Console.WriteLine("0. Exit");
            Console.WriteLine("\nEnter the number corresponding to the action you'd like to perform:");
        }
        // Add Book
        static void AddBook()
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter author's first name: ");
            string authorFirstName = Console.ReadLine();

            Console.Write("Enter author's last name: ");
            string authorLastName = Console.ReadLine();

            Console.Write("Enter publication year: ");
            int publicationYear = Convert.ToInt32(Console.ReadLine());

            var author = authors.FirstOrDefault(a => a.FirstName == authorFirstName && a.LastName == authorLastName);
            if (author == null)
            {
                author = new Author { FirstName = authorFirstName, LastName = authorLastName };
            }

            var book = new Book { Title = title, Author = author, PublicationYear = publicationYear, IsAvailable = true };
            books.Add(book);

            Console.WriteLine("Book added successfully.");
        }

       // Update Books
        static void UpdateBook()
        {
            Console.Write("Enter book title to update: ");
            string title = Console.ReadLine();

            var book = books.FirstOrDefault(b => b.Title == title);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.Write("Enter new title: ");
            string newTitle = Console.ReadLine();

            Console.Write("Enter new publication year: ");
            int newPublicationYear = Convert.ToInt32(Console.ReadLine());

            book.Title = newTitle;
            book.PublicationYear = newPublicationYear;

            Console.WriteLine("Book updated successfully.");
        }
        // Search Books
        static void SearchBooks()
        {
            Console.Write("Enter search query (title, author, borrower): ");
            string query = Console.ReadLine();

            var matchingBooks = books.Where(b =>
                b.Title.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                b.Author.FullName.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                borrowedBooks.Any(bb => bb.Book == b && (bb.Borrower.FirstName + " " + bb.Borrower.LastName).Contains(query, StringComparison.OrdinalIgnoreCase))
            );

            Console.WriteLine("Matching books:");
            foreach (var book in matchingBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author.FullName}, " +
                                  $"Publication Year: {book.PublicationYear}, " +
                                  $"Status: {(book.IsAvailable ? "Available" : "Borrowed")}");
            }
        }
        // Delete Books
        static void DeleteBook()
        {
            Console.Write("Enter book title to delete: ");
            string title = Console.ReadLine();

            var book = books.FirstOrDefault(b => b.Title == title);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            books.Remove(book);

            Console.WriteLine("Book deleted successfully.");
        }

        // List All Books
        static void ListAllBooks()
        {
            Console.WriteLine("List of all books:");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author.FullName}, " +
                                  $"Publication Year: {book.PublicationYear}, " +
                                  $"Status: {(book.IsAvailable ? "Available" : "Borrowed")}");
            }
        }
        
        // Add Author
        static void AddAuthor()
        {
            Console.Write("Enter author's first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter author's last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter date of birth (yyyy-mm-dd): ");
            DateTime dateOfBirth = DateTime.Parse(Console.ReadLine());

            var author = new Author { FirstName = firstName, LastName = lastName, DateOfBirth = dateOfBirth };
            authors.Add(author);

            Console.WriteLine("Author added successfully.");
        }
        // Add Borrower
        static void AddBorrower()
        {
            Console.Write("Enter borrower's first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter borrower's last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine();

            var borrower = new Borrower { FirstName = firstName, LastName = lastName, Email = email, PhoneNumber = phoneNumber };
            borrowers.Add(borrower);

            Console.WriteLine("Borrower added successfully.");
        }
        
        // Register Book To Borrowerer
        static void RegisterBookToBorrower()
        {
            Console.Write("Enter book title to register: ");
            string title = Console.ReadLine();

            var book = books.FirstOrDefault(b => b.Title == title);
            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Console.Write("Enter borrower's email: ");
            string borrowerEmail = Console.ReadLine();

            var borrower = borrowers.FirstOrDefault(b => b.Email == borrowerEmail);
            if (borrower == null)
            {
                Console.WriteLine("Borrower not found.");
                return;
            }

            Console.Write("Enter due date (yyyy-mm-dd): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            var borrowedBook = new BorrowedBook { Book = book, Borrower = borrower, BorrowDate = DateTime.Now, DueDate = dueDate };
            borrowedBooks.Add(borrowedBook);

            book.IsAvailable = false;

            Console.WriteLine("Book registered to borrower successfully.");
        }
        // List All Authors
        static void ListAllAuthors()
        {
            Console.WriteLine("List of all authors:");
            foreach (var author in authors)
            {
                Console.WriteLine($"Author: {author.FullName}, Date of Birth: {author.DateOfBirth}");
            }
        }
        // Listv All Borrowers
        static void ListAllBorrowers()
        {
            Console.WriteLine("List of all borrowers:");
            foreach (var borrower in borrowers)
            {
                Console.WriteLine($"Name: {borrower.FirstName} {borrower.LastName}");
                Console.WriteLine($"Email: {borrower.Email}");
                Console.WriteLine($"Phone Number: {borrower.PhoneNumber}");
                Console.WriteLine("======================");
            }
        }

        // Dispaly All Borerowed Books
        static void DisplayAllBorrowedBooks()
        {
            Console.WriteLine("List of all borrowed books:");
            foreach (var borrowedBook in borrowedBooks)
            {
                Console.WriteLine($"Book: {borrowedBook.Book.Title}");
                Console.WriteLine($"Borrower: {borrowedBook.Borrower.FirstName} {borrowedBook.Borrower.LastName}");
                Console.WriteLine($"Borrow Date: {borrowedBook.BorrowDate}");
                Console.WriteLine($"Due Date: {borrowedBook.DueDate}");
                Console.WriteLine("======================");
            }
        }
        // Filter Books by Status
        static void FilterBooksByStatus()
        {
            Console.WriteLine("Select filter option:");
            Console.WriteLine("1. Available");
            Console.WriteLine("2. Borrowed");

            int choice = Convert.ToInt32(Console.ReadLine());

            bool status = choice switch
            {
                1 => true,
                2 => false,
                _ => true, // Default to available
            };

            var filteredBooks = books.Where(b => b.IsAvailable == status).ToList();

            foreach (var book in filteredBooks)
            {
                Console.WriteLine(book);
            }
        }


    }

    // Class definitions
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

        public string FullName => $"{FirstName} {LastName}"; // Add this line to compute full name
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