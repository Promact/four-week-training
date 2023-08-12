using LibraryManagement.Models;
using LibraryManagement.Repository;
using LibraryManagement.Repository.IRepository;

namespace LibraryManagement
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            // Initialize collections for books, authors, and borrowers
            List<Book> books = new List<Book>();
            List<Author> authors = new List<Author>();
            List<Borrower> borrowers = new List<Borrower>();
            List<BorrowedBook> borrowedBooks = new List<BorrowedBook>();


            IBookRepository bookRepository = new BookRepository(books);
            IAuthorRepository authorRepository = new AuthorRepository(authors);
            IBorrowerRepository borrowerRepository = new BorrowerRepository(borrowers);
            IBorrowedBookRepository borrowedBookRepository = new BorrowedBookRepository(borrowedBooks);

            Library library = new Library(bookRepository, authorRepository, borrowerRepository, borrowedBookRepository);

            // Main program loop
            while (true)
            {
                DisplayMenu();

                int choice, index;

                try
                {
                    int.TryParse(Console.ReadLine(), out choice);

                    switch (choice)
                    {
                        // Add cases for each menu option
                        case 1:
                            // Call Add book 
                            await library.AddBookAsync();
                            break;

                        case 2:
                            // Update a book
                            Console.WriteLine("Enter the index of book list to update:");
                            index = int.Parse(Console.ReadLine());
                            await library.UpdateBookAsync(index);
                            break;

                        case 3:
                            // Delete a book
                            Console.WriteLine("Enter the index of book to delete:");
                            index = int.Parse(Console.ReadLine());

                            await library.DeleteBookAsync(index);

                            break;

                        case 4:
                            // List all books
                            await library.ListAllBookAsync();
                            break;

                        case 5:
                            // Add an author
                            await library.AddAuthorAsync();
                            break;

                        case 6:
                            // Update an author
                            Console.WriteLine("Enter the index of author list to update:");
                            index = int.Parse(Console.ReadLine());

                            await library.UpdateAuthorAsync(index);

                            break;

                        case 7:
                            // Delete an author
                            Console.WriteLine("Enter the index of author list to delete:");
                            index = int.Parse(Console.ReadLine());

                            await library.DeleteAuthorAsync(index);

                            break;

                        case 8:
                            // List all author
                            await library.ListAllAuthorAsync();
                            break;

                        case 9:
                            // Add a borrower
                            await library.AddBorrowerAsync();

                            break;

                        case 10:
                            // Update a borrower
                            Console.WriteLine("Enter the index of borrower list to update:");
                            index = int.Parse(Console.ReadLine());
                            await library.UpdateBorrowerAsync(index);

                            break;

                        case 11:
                            // Delete a borrower
                            Console.WriteLine("Enter the index of borrower list to delete:");
                            index = int.Parse(Console.ReadLine());
                            await library.DeleteBorrowerAsync(index);
                            break;

                        case 12:
                            // List all borrowers
                            await library.ListAllBorrowerAsync();
                            break;

                        case 13:
                            // Register a book to a borrower
                            Console.WriteLine("Enter index of book list that you want to register: ");
                            int bookIndex = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter index of borrower list that you want to register: ");
                            int borrowerIndex = int.Parse(Console.ReadLine());

                            await library.RegisterBoookToBorrowerAsync(bookIndex, borrowerIndex);
                            break;

                        case 14:
                            // List all borrowed books
                            await library.DisplayBorrowedBookAsync();
                            break;
                        case 15:
                            //Search books
                            Console.WriteLine("Search book by title");
                            string searchString = Console.ReadLine();
                            await library.SearchByAsync(searchString);
                            break;
                        case 16:
                            // Filter books by status
                            Console.WriteLine("Check Book is available or borrowed.");
                            bool status = Console.ReadLine().ToLower() == "available";
                            await library.FilterByStatus(status);
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
            Console.WriteLine("12. List all borrowers");
            Console.WriteLine("13. Register a book to a borrower");
            Console.WriteLine("14. Display borrowed books");
            Console.WriteLine("15. Search books");
            Console.WriteLine("16. Filter books by status");
            Console.WriteLine("\nEnter the number corresponding to the action you'd like to perform:");
        }
    }
}