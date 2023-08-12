using LibraryManagement.UI;

namespace LibraryManagement
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Operations operations = new Operations();

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
                        await operations.AddNewBook();
                        break;
                    case 2:
                        await operations.UpdateBook();
                        break;
                    case 3:
                        await operations.DeleteBook();
                        break;
                    case 4:
                        await operations.DisplayAllBooks();
                        break;
                    case 5:
                        await operations.AddAuthor();
                        break;
                    case 6:
                        await operations.UpdateAuthor();
                        break;
                    case 7:
                        await operations.DeleteAuthor();
                        break;
                    case 8:
                        await operations.DisplayAllAuthors();
                        break;
                    case 9:
                        await operations.AddBorrower();
                        break;
                    case 10:
                        await operations.UpdateBorrower();
                        break;
                    case 11:
                        await operations.DeleteBorrower();
                        break;
                    case 12:
                        await operations.DisplayAllBorrower();
                        break;
                    case 13:
                        await operations.RegisterBookToBorrower();
                        break;
                    case 14:
                        await operations.DisplayBorrowedBook();
                        break;
                    case 15:
                        await operations.SearchBooks();
                        break;
                    case 16:
                        await operations.SearchBookByStatus();
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                };
            }
        }
        private static void DisplayMenu()
        {
            // Display the menu options
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Library Management System");
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
            Console.WriteLine("0. Exit");
            Console.WriteLine("\nEnter the number corresponding to the action you'd like to perform:");
            Console.ForegroundColor= ConsoleColor.White;
        }
    }
}