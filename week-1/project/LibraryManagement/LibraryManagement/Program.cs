using System;
using System.Collections.Generic;
using System.Net;
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
            List<Borrower> borrowersDetail = new List<Borrower>();

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
                        Book.AddBook(books,authors);

                        break;
                    case 2:
                        // Add a book
                        Book.UpdateBook(books);

                        break;
                    case 3:
                        // Add a book
                        Book.DeleteBook(books);

                        break;
                    case 4:
                        // Add a book
                        Book.ListAllBooks(books);

                        break;
                    case 5:
                        // Add a book
                        Author.AddAuthor(authors,books);

                        break;
                    case 6:
                        // Add a book
                        Author.UpdateAuthor(authors);

                        break;
                    case 7:
                        // Add a book
                        Author.DeleteAuthor(authors);

                        break;
                    case 8:
                        // Add a book
                        Author.ListAllAuthor(authors);

                        break;
                    case 9:
                        // Add a book
                        Borrower.AddBorrower(borrowers);

                        break;
                    case 10:
                        // Add a book
                        Borrower.UpdateBorrower(borrowers);

                        break;
                    case 11:
                        // Add a book
                        Borrower.DeleteBorrower(borrowers);

                        break;
                    case 12:
                        // Add a book
                        Borrower.ListAllBorrowers(borrowers);

                        break;

                    case 13:
                        
                            Console.WriteLine("Here is Registered borrowers");
                            Borrower.ListAllBorrowers(borrowers);
                            Console.WriteLine("Here is Books");
                            Book.ListAllBooks(books);
                            Borrower.RegisteredBorrowers(borrowers,books, borrowersDetail);
                            break;
                        

                    case 14:
                        Borrower.ShowBorrowedBooks(books,borrowersDetail);
                        break;
                    // ...
                    case 15:
                        Book.SearchBooks(books);
                        break;
                    case 16:
                        Book.filterbooks(books);
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
            Console.WriteLine("5. Add an author");
            Console.WriteLine("6. Update an author");
            Console.WriteLine("7. Delete an author");
            Console.WriteLine("8. List all author");
            Console.WriteLine("9. Add a borrower");
            Console.WriteLine("10. Update a borrower");
            Console.WriteLine("11. Delete a borrower");
            Console.WriteLine("12. List all borrower");
            Console.WriteLine("13. Register a book to a borrower");
            Console.WriteLine("14. Display borrowed books");
            Console.WriteLine("15. Search books");

            Console.WriteLine("16. Filter books by status");
            Console.WriteLine("\nEnter the number corresponding to the action you'd like to perform:");
        }
    }

    // Class definitions
     public class Book
    {
        public string Title { get; set; }

        public static int bookIdCounter = 1;
        public  int BookId { get; set; }
        public Author Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
         

        // Add a book
      public  static void AddBook(List<Book> books, List<Author> authors)
        {
            Book newBook = new Book();

            Console.Write("Enter Title: ");
            newBook.Title = Console.ReadLine();

            Console.Write("Enter Publication Year: ");
            newBook.PublicationYear = Convert.ToInt32(Console.ReadLine());
            newBook.IsAvailable = true;

            // Similar code to input Author, PublicationYear, IsAvailable



            newBook.BookId = bookIdCounter++;
            books.Add(newBook);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book Added Sucessfully!");
            Console.ResetColor();
            Author newAuthor = new Author();

            Console.Write("Enter authors First Name of this book: ");
            newAuthor.FirstName = Console.ReadLine();
            Console.Write("Enter authors Last Name of this book: ");
            newAuthor.LastName = Console.ReadLine();
            Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
            string dobInput = Console.ReadLine();
            DateTime dob;

            if (DateTime.TryParse(dobInput, out dob))
            {
                newAuthor.DateOfBirth = dob;
                //Console.WriteLine("Date of Birth: " + dob.ToShortDateString());
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter in yyyy-MM-dd format.");
                return;
            }


            newAuthor.authorId = Author.authorIdCounter++;
            authors.Add(newAuthor);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Author Added Sucessfully!");
            Console.ResetColor();

        }

        public static void UpdateBook(List<Book> books)
        {
            if(books.Any()) { 
            ListAllBooks(books);
            Console.Write("Enter the Id of the book to update: ");
            int bookId = Convert.ToInt32(Console.ReadLine());

                //Book bookToUpdate = books.Find(book => book.BookId == bookId);
                Book bookToUpdate = books.FirstOrDefault(book => book.BookId == bookId);


                if (bookToUpdate != null)
            {
                Console.Write("Enter Updated Title : ");
                bookToUpdate.Title = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Book Updated Sucessfully!");
                Console.ResetColor();

            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("No Books are available please add books first .");

                Console.ResetColor();

            }
}

        public static void DeleteBook(List<Book> books)
        {
            if(books.Any()) { 

            ListAllBooks(books);
            Console.Write("Enter the Id of the book to delete: ");
            int  bookId = Convert.ToInt32(Console.ReadLine());

            Book bookIdToDelete = books.Find(book => book.BookId == bookId);

            if (bookIdToDelete != null)
            {
                books.Remove(bookIdToDelete);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Book Deleted Sucessfully!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("No Books are available please add books first .");

                Console.ResetColor();

            }
        }

        public static void ListAllBooks(List<Book> books)
        {
            if (books.Any())
            {

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("List of Books:");
                foreach (Book book in books)
                {
                    Console.WriteLine($"Title: {book.Title} Id :{book.BookId}");
                    // Add more properties as needed
                }
                Console.ResetColor();
            }else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("No Books are available please add books first .");

                Console.ResetColor();
                return;
            }
        }
        public static void SearchBooks(List<Book> books)
        {
            if (books.Any())
            {
                Console.Write("Enter search keyword: ");
                string searchKeyword = Console.ReadLine();

                //var searchResults = books.Where(book => book.Title.Contains(searchKeyword));
                var searchResults = books.Where(book => book.Title.IndexOf(searchKeyword, StringComparison.OrdinalIgnoreCase) >= 0);


                Console.ForegroundColor = ConsoleColor.Blue;
                if (searchResults.Any())
                {
                    foreach (var book in searchResults)
                    {
                        //Console.WriteLine($"Title: {book.Title}, Author: {book.Author.FirstName} {book.Author.LastName}");

                        Console.WriteLine($"Title: {book.Title} Publication : {book.PublicationYear} Available : {book.IsAvailable}");
                    }

                }
                else
                {
                    Console.WriteLine("No matching books found.");
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("No Books are available please add books first .");

                Console.ResetColor();

            }
        }
        public static void filterbooks(List<Book> books)
        {
            bool desiredStatus = true; 

            var filteredBooks = books.Where(book => book.IsAvailable == desiredStatus).ToList();
            Console.ForegroundColor = ConsoleColor.Blue;
            if (filteredBooks.Any())
            {
                
                Console.WriteLine($"Books with availability status IsAvailable = {desiredStatus}:");
            }else
            {
                desiredStatus = false;
                Console.WriteLine($"Books with availability status IsAvailable = {desiredStatus}:");
            }
            foreach (var book in filteredBooks)
            {
                Console.WriteLine($"{book.Title}");
            }
            Console.ResetColor();
        }




    }

    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public static int authorIdCounter = 1;
        public   int authorId { get; set; }
        public DateTime DateOfBirth { get; set; }

        public static void AddAuthor(List<Author> authors , List<Book>books)
        {
            Author newAuthor = new Author();

          
            Console.Write("Enter authors First Name: ");
            newAuthor.FirstName = Console.ReadLine();
            Console.Write("Enter authors Last Name: ");
            newAuthor.LastName = Console.ReadLine();
            Console.Write("Enter Date of Birth (yyyy-MM-dd): ");
            string dobInput = Console.ReadLine();
            DateTime dob;

            if (DateTime.TryParse(dobInput, out dob))
            {
                newAuthor.DateOfBirth = dob;
                //Console.WriteLine("Date of Birth: " + dob.ToShortDateString());
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter in yyyy-MM-dd format.");
                return;
            }

            newAuthor.authorId = authorIdCounter++;
            authors.Add(newAuthor);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Author Added Sucessfully!");
            Console.ResetColor();
            Book newBook = new Book();

            Console.Write("Enter Title to add new book of this author : ");
            newBook.Title = Console.ReadLine();

            Console.Write("Enter Publication Year: ");
            newBook.PublicationYear = Convert.ToInt32(Console.ReadLine());
            newBook.IsAvailable = true;

            newBook.BookId = Book.bookIdCounter++;
            books.Add(newBook);
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Book Added Sucessfully!");
            Console.ResetColor();

        }

        // Update a book
        public static void UpdateAuthor(List<Author> authors)
        {
            if (authors.Any())
            {
                ListAllAuthor(authors);

                Console.Write("Enter Author ID To Update: ");
                int searchAuthorId = Convert.ToInt32(Console.ReadLine());
                //Author NameToUpdate = authors.Find(author => author.authorId == searchAuthorId);
                Author NameToUpdate = authors.FirstOrDefault(author => author.authorId == searchAuthorId);


                if (NameToUpdate != null)
                {
                  
                    Console.Write("Enter the First Name of the Author to update:  ");
                    NameToUpdate.FirstName = Console.ReadLine();
                    Console.Write("Enter the Last Name of the Author to update:  ");
                    NameToUpdate.LastName = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Author Updated Sucessfully!");
                    Console.ResetColor();


                }
                else
                {
                    Console.WriteLine("Name not found.");
                }
            }else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("No Author are available please add author first .");

                Console.ResetColor(); return;
            }
        }

        
        public static void DeleteAuthor(List<Author> authors)
        {
            if (authors.Any())
            {
                Console.Write("Enter the Id of the Author to delete: ");
                int AuthorId = Convert.ToInt32(Console.ReadLine());


                //Author NameToDelete = authors.Find(author => author.authorId == AuthorId);
                Author NameToDelete = authors.FirstOrDefault(author => author.authorId == AuthorId);


                if (NameToDelete != null)
                {
                    authors.Remove(NameToDelete);
                    Console.WriteLine("Author deleted.");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Book Deleted Sucessfully!");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Author not found.");
                }
            }
        else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("No Author are available please add author first .");

                Console.ResetColor(); return;
            }
}

        // List all books
        public static void ListAllAuthor(List<Author> authors)
        {
            if (authors.Any())
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("List of Authors:");
                foreach (Author author in authors)
                {
                    Console.WriteLine($"AuthorID:{author.authorId} FirstName: {author.FirstName}, LastName: {author.LastName} DateOfBirth: {author.DateOfBirth}");
          
                }
                Console.ResetColor();
            }
        else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("No Author are available please add author first .");

                Console.ResetColor(); return;
            }
}
    }

    public class Borrower
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Book Book { get; set; }
        

        public string formattedDueDate { get; set; }
        public string formattedborrowedDate { get; set; }

        public static void AddBorrower(List<Borrower> borrowers)
        {
            Borrower newborrower=new Borrower();
           
            Console.Write("Enter Borrowers First Name: ");
            newborrower.FirstName = Console.ReadLine();
            Console.Write("Enter Borrowers Last Name: ");
            newborrower.LastName = Console.ReadLine();
            Console.Write("Enter Borrowers Email Id: ");
            newborrower.Email = Console.ReadLine();
            Console.Write("Enter Borrowers Mob No: ");
            newborrower.PhoneNumber = Console.ReadLine();

            borrowers.Add(newborrower);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Borrower Added Sucessfully!");
            Console.ResetColor();
        }

        public static void UpdateBorrower(List<Borrower> borrowers)
        {
            if (borrowers.Count > 0)
            {
                ListAllBorrowers(borrowers);
                Console.WriteLine("enter Email-Id of borrower to update");
                string EMAIL = Console.ReadLine();
               
                Borrower UpdateBorrower = borrowers.Find(borrower => borrower.Email == EMAIL);

                if (UpdateBorrower != null)
                {
                    Console.Write("Enter Borrowers updated First Name: ");
                    UpdateBorrower.FirstName = Console.ReadLine();
                    Console.Write("Enter Borrowers updated Last Name: ");
                    UpdateBorrower.LastName = Console.ReadLine();
                    Console.Write("Enter Borrowers updated Email Id: ");
                    UpdateBorrower.Email = Console.ReadLine();
                    Console.Write("Enter Borrowers updated Mob No: ");
                    UpdateBorrower.PhoneNumber = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Borrower Updated Sucessfully!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("borrower not found.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No borrowers present .");
                Console.ResetColor();   
                return;
            }
        }

        public static void DeleteBorrower(List<Borrower> borrowers)
        {
            
            if (borrowers.Count>0)
            {
                ListAllBorrowers(borrowers);
                Console.WriteLine("enter EMAIL-ID of borrower to delete");
                string EMAIL = Console.ReadLine();
                
                Borrower EmailToDelete = borrowers.Find(borrower => borrower.Email == EMAIL );

                if (EmailToDelete != null)
                {
                    borrowers.Remove(EmailToDelete);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Borrower Deleted Sucessfully!");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("borrower not found.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("No borrowers present."); Console.ResetColor();
                return;
            }
        }

        public static void ListAllBorrowers(List<Borrower> borrowers)
        {
            if (borrowers.Count == 0)
            {
                Console.ForegroundColor= ConsoleColor.DarkRed;
                Console.WriteLine("No borrowers available."); 
                Console.ResetColor();
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("List of all borrowers:");
                for (int i = 0; i < borrowers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {borrowers[i].FirstName} {borrowers[i].LastName}   {borrowers[i].Email}  {borrowers[i].PhoneNumber}");
                }
                Console.ResetColor ();
            }
        }
      
        public static void ShowBorrowedBooks(List<Book> books, List<Borrower> borrowersDetail)
        {
            if (borrowersDetail.Any())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Borrowed Books:");

                foreach (var book in books)
                {
                    if (!book.IsAvailable)
                    {
                        Console.WriteLine($"Book ID: {book.BookId}");
                        Console.WriteLine($"Book Title: {book.Title}");

                    }
                }
                foreach (var borrower in borrowersDetail)
                {
                    Console.WriteLine($"Book borrowers email id is  " +
                        $"{borrower.Email}");
                    Console.WriteLine($"Book borrowed date: {borrower.formattedborrowedDate}");
                    Console.WriteLine($"Book borrowed due date: {borrower.formattedDueDate}");
                    Console.WriteLine();

                }

                Console.ResetColor();
            }else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No Books Borrowed yet !");
                Console.ResetColor();

            }
        }

        internal static void RegisteredBorrowers(List<Borrower> borrowers, List<Book> books, List<Borrower> borrowersDetail)
        {
            if (borrowers.Any())
            {
                Console.Write("Enter the Email-Id of the borrower you want to register a book for: ");
                string borrowerEmail = Console.ReadLine();
                Borrower borrower = new Borrower();
                    Console.Write("Enter tittle of Book ");
                    String BookName=Console.ReadLine();
                    
                    Book bookToUpdate = books.Find(book => book.Title == BookName);

                    if (bookToUpdate != null)
                    {
                    borrower.Email = borrowerEmail;
                        bookToUpdate.IsAvailable = false;

                    }

                    Console.Write("Enter Borrowed Date (yyyy-mm-dd): ");
                    DateTime borrowedDate = DateTime.Parse(Console.ReadLine());
                    string formattedborrowedDates = borrowedDate.ToString("yyyy-MM-dd");
                borrower.formattedborrowedDate = formattedborrowedDates;
                    Console.Write("Enter Due Date (yyyy-mm-dd): ");
                    DateTime dueDate = DateTime.Parse(Console.ReadLine());
                    string formattedDueDates = dueDate.ToString("yyyy-MM-dd");
                borrower.formattedborrowedDate = formattedDueDates;
                borrowersDetail.Add(borrower);
          
                Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Book registration successful!");
                    Console.ResetColor();
                }
              
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("No borrower Present Here please add borowwer first .");
                Console.ResetColor();
            }
        }
    }
}