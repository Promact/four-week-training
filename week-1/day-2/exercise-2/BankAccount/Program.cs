namespace BankAccount
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Creating instances of SavingsAccount and CheckingAccount
            SavingsAccount savingsAccount = new SavingsAccount(34572637483, 1000.50, 0.4);
            CheckingAccount checkingAccount = new CheckingAccount(34572637483, 200, 400);

            // Performing operations on the savings account
            savingsAccount.Deposit(1000);
            savingsAccount.Withdraw(750);
            Console.WriteLine($"SavingsAccount Balance is: {savingsAccount.Balance}");

            // Performing operations on the checking account
            checkingAccount.Deposit(1000);
            checkingAccount.Withdraw(3000);
            Console.WriteLine($"CheckingAccount Balance is: {checkingAccount.Balance}");
        }
    }
}