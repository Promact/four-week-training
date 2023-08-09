namespace BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create SavingsAccount and CheckingAccount objects and perform operations
            SavingsAccount savingsAccount = new SavingsAccount(1234, 14.00, 10.00);
            CheckingAccount checkingAccount = new CheckingAccount(789012, 1500.00, 500.00);

            savingsAccount.DisplayInfo();
            savingsAccount.Deposit(200.00);
            savingsAccount.Withdraw(300.00);
            Console.WriteLine();

            checkingAccount.DisplayInfo();
            checkingAccount.Deposit(300.00);
            checkingAccount.Withdraw(200.00);
            checkingAccount.Withdraw(1800.00);

            Console.ReadLine();
        }
    }
}