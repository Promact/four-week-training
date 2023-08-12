using static System.Reflection.Metadata.BlobBuilder;

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
            List<BorrowedBook> borrowedBooks = new List<BorrowedBook>();

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
                        Book.AddBook(books, authors, true);
                        break;
                    case 2:
                        Book.UpdateBook(books);
                        break;
                    case 3:
                        Book.DeleteBook(books);
                        break;
                    case 4:
                        Book.GetAllBooks(books);
                        break;
                    case 5:
                        Author.AddAuthor(authors, books, true);
                        break;
                    case 6:
                        Author.UpdateAuthor(authors);
                        break;
                    case 7:
                        Author.DeleteAuthor(authors);
                        break;
                    case 8:
                        Author.GetAllAuthors(authors);
                        break;
                    case 9:
                        Borrower.AddBorrower(borrowers);
                        break;
                    case 10:
                        Borrower.UpdateBorrower(borrowers);
                        break;
                    case 11:
                        Borrower.DeleteBorrower(borrowers);
                        break;
                    case 12:
                        Borrower.GetAllBorrowers(borrowers);
                        break;
                    case 13: 
                        BorrowedBook.BookToABorrower(borrowers, books,borrowedBooks);
                        break;
                    case 14:
                        BorrowedBook.DisplayBorrowedBooks(borrowedBooks);
                        break;
                    case 15:
                        Book.SearchBook(books);
                        break;
                    case 16:
                        Book.FilterBookByStatus(books);
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
            Console.ResetColor();
            Console.WriteLine("Welcome to the Library Management System!\n");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Update a book");
            Console.WriteLine("3. Delete a book");
            Console.WriteLine("4. List all books");
            Console.WriteLine("5. Add a author");
            Console.WriteLine("6. Update a author");
            Console.WriteLine("7. Delete a author");
            Console.WriteLine("8. List all author");
            Console.WriteLine("9. Add a borrower");
            Console.WriteLine("10. Update a borrower");
            Console.WriteLine("11. Delete a borrower");
            Console.WriteLine("12. List all borrower");
            Console.WriteLine("13. Assign book to a borrower");
            Console.WriteLine("14. Display all borrowed books");
            Console.WriteLine("15. Search book by title");
            Console.WriteLine("16. Filter book by status");

            // ...Add Other options here
            Console.WriteLine("16. Filter books by status");
            Console.WriteLine("\nEnter the number corresponding to the action you'd like to perform:");
        }
    }

    // Class definitions
    class Book
    {
        public int id;
        public string Title { get; set; }
        public Author Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }

        // Inside the Program class
        public static void AddBook(List<Book> books, List<Author> authors, bool isAddAuthor)
        {
            Book newBook = new Book();

            Console.WriteLine("Add a new book:");

            Console.Write("Enter title: ");
            newBook.Title = Console.ReadLine();

            Console.Write("Enter publication year: ");
            int publicationYear;

            int.TryParse(Console.ReadLine(), out publicationYear);

            //if true then addauthor call otherwise not 
            if (isAddAuthor)
                Author.AddAuthor(authors, books, false);

            newBook.id = books.Count + 1;

            books.Add(newBook);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book added successfully.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void UpdateBook(List<Book> books)
        {

            GetAllBooks(books);

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Here is all book list Choose id number that you want to update : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Book findBook = books.FirstOrDefault(x => x.id == id);

            if (findBook != null)
            {
                Console.Write("Title : ");
                findBook.Title = Console.ReadLine();
    
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book updated successfully");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Book not found");
            }
        }

        public static void GetAllBooks(List<Book> books)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("List of all books:");
            foreach (var book in books)
            {
                Console.WriteLine($"Book ID: {book.id}, Title: {book.Title}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DeleteBook(List<Book> books)
        {

            GetAllBooks(books);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Here is all book list Choose id number that you want to delete : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Book findBook = books.FirstOrDefault(x => x.id == id);

            if (findBook != null)
            {
                books.Remove(findBook);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Book deleted successfully");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Book not found");
            }

        }

        public static void SearchBook(List<Book> books)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please write title for search book : ");
            String findBookByTitle = Console.ReadLine();

            List<Book> searchBook = books.Where(b => b.Title.Contains(findBookByTitle)).ToList();

            if (searchBook == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("book not found Please check title again");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                foreach (Book book in searchBook)
                {
                    Console.WriteLine($"Id : {book.id} || Title : {book.Title}");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void FilterBookByStatus(List<Book> books)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Book is available \n2. Book is not available");
            int ope = Convert.ToInt32(Console.ReadLine());

            if(ope==1)
            {
                List<Book> filterBooks = books.Where(b => b.IsAvailable == true).ToList();
                foreach (Book book in filterBooks)
                {
                    Console.WriteLine($"Id : {book.id} || Title : {book.Title}");
                }
            }
            else
            {
                List<Book>  filterBooksNoTAvailable = books.Where(b => b.IsAvailable == true).ToList();
                foreach (Book book in filterBooksNoTAvailable)
                {
                    Console.WriteLine($"Id : {book.id} || Title : {book.Title}");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;

        }


    }

    class Author
    {
        public int id;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public static void AddAuthor(List<Author> authors, List<Book> books, bool isAddBook)
        {
            Author newAuthor = new Author();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Add a new author:");
            Console.Write("Enter author's first name: ");

            newAuthor.FirstName = Console.ReadLine();
            Console.Write("Enter author's last name: ");
            newAuthor.LastName = Console.ReadLine();

            Console.Write("Enter author's id: ");

            newAuthor.id = Convert.ToInt32(Console.ReadLine());

            if (isAddBook)
                Book.AddBook(books, authors, false);

            Console.Write("Enter author's date of birth (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dateOfBirth))
            {
                authors.Add(newAuthor);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Author added successfully.");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid date format. Author not added.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void GetAllAuthors(List<Author> authors)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("List of all Authors : ");
            foreach (Author author in authors)
            {
                Console.WriteLine($"Author id : {author.id} || Author name : {author.FirstName} {author.LastName}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void UpdateAuthor(List<Author> authors)
        {
            Console.ForegroundColor = ConsoleColor.White;
            GetAllAuthors(authors);

            Console.WriteLine("Here is list of all authors please write id for update author details : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Author findAuthor = authors.FirstOrDefault(a => a.id == id);
            if (findAuthor != null)
            {
                Console.Write("Firstname : ");
    
                findAuthor.FirstName = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Author updated successfully");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Author not found");
            }


            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void DeleteAuthor(List<Author> authors)
        {
            Console.ForegroundColor = ConsoleColor.White;
            GetAllAuthors(authors);

            Console.WriteLine("Here is list of all authors please write id for delete author details : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Author findAuthor = authors.FirstOrDefault(a => a.id == id);
            if (findAuthor != null)
            {
                authors.Remove(findAuthor);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Author deleted successfully");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("borrower not found");
            }



        }
    }

    class Borrower
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static void AddBorrower(List<Borrower> borrowers)
        {
            Console.ForegroundColor = ConsoleColor.White;

            Borrower borrower = new Borrower();
            Console.WriteLine("Add borrower details : ");

            Console.Write("Firstame : ");
            borrower.FirstName = Console.ReadLine();

            Console.Write("Lastname : ");
            borrower.LastName = Console.ReadLine();

            Console.Write("Email : ");
            borrower.Email = Console.ReadLine();

            Console.Write("Phonenumber : ");
            borrower.PhoneNumber = Console.ReadLine();

            borrower.Id = borrowers.Count * 200;
            borrowers.Add(borrower);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Borrower added successfully.");
            Console.ForegroundColor = ConsoleColor.White;


        }

        public static void GetAllBorrowers(List<Borrower> borrowers)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("Borrower's List : ");
            foreach (Borrower b in borrowers)
            {
                Console.WriteLine($"Name : {b.FirstName} \nEmail : {b.Email} \nPhoneNumber : {b.PhoneNumber}");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void UpdateBorrower(List<Borrower> borrowers)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Here is all borrowers list please write borrowers's id for update details : ");

            GetAllBorrowers(borrowers);
            Console.Write("Email : ");
            String EmailForSearch = Console.ReadLine();

            Borrower findBorrower = borrowers.FirstOrDefault(b => b.Email == EmailForSearch);

            if (findBorrower != null)
            {
                Console.Write("Name : ");
                findBorrower.FirstName = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully updated borrower details");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("borrower not found");
            }

        }

        public static void DeleteBorrower(List<Borrower> borrowers)
        {
            Console.ForegroundColor = ConsoleColor.White;

            GetAllBorrowers(borrowers);

            Console.WriteLine("Here is all borrowers list please write borrowers's id for delete borower: ");
            Console.Write("Email : ");
            String EmailForSearch = Console.ReadLine();
            Borrower findBorrower = borrowers.FirstOrDefault(b => b.Email == EmailForSearch);

            if (findBorrower != null)
            {
                borrowers.Remove(findBorrower);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully delete borrower");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("borrower not found");
            }
        }

    }

    class BorrowedBook
    {
        public Book Book { get; set; }
        public Borrower Borrower { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }


        public static void BookToABorrower(List<Borrower> borrowers,List<Book> books,List<BorrowedBook> borrowBooks)
        {
            Console.ForegroundColor = ConsoleColor.White;

            BorrowedBook borrowBookObj = new BorrowedBook();

            Console.WriteLine("Register a book to a borrower : ");
            Borrower.GetAllBorrowers(borrowers);

            Console.Write("Write id which borrower you want to assign a book : ");
            String EmailForSearch = Console.ReadLine();

            Borrower findBorrower = borrowers.FirstOrDefault(b => b.Email == EmailForSearch);

            if (findBorrower == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Borrower not found Please check id again");

            }
            else
            {
                borrowBookObj.Borrower = findBorrower;

            }

            Book.GetAllBooks(books);

            Console.WriteLine("Write id of book which book you want to assign a borrower : ");
            int bookId = Convert.ToInt32(Console.ReadLine());

            Book findBook = books.FirstOrDefault(book => book.id == bookId);

            if(findBook==null)
            { 
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("book not found Please check id again");
            }


            borrowBookObj.Book = findBook;

            findBook.IsAvailable = false;

            borrowBookObj.BorrowDate = DateTime.Today;
            borrowBookObj.DueDate = borrowBookObj.BorrowDate.AddDays(30);

            borrowBooks.Add(borrowBookObj);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Successfully borrowed book");
            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void DisplayBorrowedBooks(List<BorrowedBook> borrowBooks)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Borrowed books : ");
            foreach(BorrowedBook boroowbook in borrowBooks)
            {
                Console.WriteLine($"Id : {boroowbook.Book.id} || Name : {boroowbook.Book.Title}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

    }

}