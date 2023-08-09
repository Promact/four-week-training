using System;

namespace Day2_BankAccount
{
    public class Program
    {
        static void Main(string[] args)
        {
            String accountNo = "Acc1";
            double balance = 20000;

            SavingAccount savingAccount = new SavingAccount(accountNo, balance);
            CheckingAccount checkingAccount = new CheckingAccount(accountNo, balance);

            Console.ForegroundColor = ConsoleColor.Yellow;

            try
            {
                Console.WriteLine("Please Enter operation Number \n 1 => for withdrawal \n 2 => deposit");
                int ope = Convert.ToInt32(Console.ReadLine());

                int amount;
                Console.WriteLine("Please enter the amount:");
                amount = Convert.ToInt32(Console.ReadLine());

                if (ope == 1)
                {
                    savingAccount.withdraw(amount);
                    checkingAccount.withdraw(amount);
                }
                else if (ope == 2)
                {
                    savingAccount.Deposit(amount + 1000);
                    checkingAccount.Deposit(amount + 1000);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid operation.");
                }
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input format.");
            }
        }
    }
}
