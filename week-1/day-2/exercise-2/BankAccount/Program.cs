namespace Day2_BankAcount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String accountNo = "Acc1";
            double balance = 20000;

            SavingAccount savingAccount = new SavingAccount(accountNo, balance);
            CheckingAccount checkingAccount = new CheckingAccount(accountNo, balance);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Please Enter Number \n 1=> for withdrawl \n 2=> deposit");
            int ope = Convert.ToInt32(Console.ReadLine());
            int amount;
            Console.WriteLine("Please enter amount that you want to withdraw");
            try
            {
                amount = Convert.ToInt32(Console.ReadLine());
                if (ope == 1)
                {
                    savingAccount.withdraw(amount);
                    checkingAccount.withdraw(amount);
                    Console.ReadKey();

                }
                else
                {
                    savingAccount.Deposit(amount + 1000);
                    checkingAccount.Deposit(amount + 1000);
                    Console.ReadKey();

                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input format");
                Console.ReadKey();

            }
            
        
        }
    }
}