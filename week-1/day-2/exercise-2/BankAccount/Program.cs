namespace BankAccount
{

    public class Program
    {
        static void Main(string[] args)
        {
            // Create SavingsAccount and CheckingAccount objects and perform operations
            Console.WriteLine("Enter 1 => Saving Account");
            Console.WriteLine("Enter 2 => Checking Account");
            bool isFirstIteration = true;
            int YourChoice = 0;
            do
            {
                if (!isFirstIteration && YourChoice != 1 && YourChoice != 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please Enter Valid Account Choice !!!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Please Your Account Choice : ");
                Console.ForegroundColor = ConsoleColor.White;

                isFirstIteration = false;

            } while (!int.TryParse(Console.ReadLine(), out YourChoice) || (YourChoice != 1 && YourChoice != 2));

            if (YourChoice == 1)
            {
                SavingsAccount savingsAccount = new(782378, 5000, 0.05);
                Console.WriteLine("Enter 1 => Deposit");
                Console.WriteLine("Enter 2 => Withdraw");

                int Choice = TansactionChoiceInput();
                double Amount = TakeInputAmount();
                if (Choice == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Please wait ......");
                    Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.White;
                    savingsAccount.Deposit(Amount);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Please wait ......");
                    Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.White;
                    savingsAccount.Withdraw(Amount);
                }
            }
            else
            {
                CheckingAccount checkingAccount = new(782378, 5000, 3000);
                Console.WriteLine("Enter 1 => Deposit");
                Console.WriteLine("Enter 2 => Withdraw");

                int Choice = TansactionChoiceInput();
                double Amount = TakeInputAmount();
                if (Choice == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Please wait ......");
                    Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.White;
                    checkingAccount.Deposit(Amount);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Please wait ......");
                    Thread.Sleep(2000);
                    Console.ForegroundColor = ConsoleColor.White;
                    checkingAccount.Withdraw(Amount);
                }
            }
        }
        private static double TakeInputAmount()
        {
            double amount = 0;
            bool isFirstIteration = true;
            do
            {
                if (!isFirstIteration && amount == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please Enter Correct amount !!!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Please Enter Amount : ");
                Console.ForegroundColor = ConsoleColor.White;
                isFirstIteration = false;

            } while (!double.TryParse(Console.ReadLine(), out amount));
            return amount;
        }

        private static int TansactionChoiceInput()
        {
            int TransactionChoice = 0;
            bool isFirstIteration = true;
            do
            {
                if (!isFirstIteration && TransactionChoice != 1 && TransactionChoice != 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please Enter Valid Transaction Choice !!!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Please Enter Transaction Choice : ");
                Console.ForegroundColor = ConsoleColor.White;
                isFirstIteration = false;

            } while (!int.TryParse(Console.ReadLine(), out TransactionChoice) || (TransactionChoice != 1 && TransactionChoice != 2));
            return TransactionChoice;
        }
    }
}