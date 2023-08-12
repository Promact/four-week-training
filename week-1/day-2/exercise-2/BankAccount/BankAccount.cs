using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public abstract class BankAccount
    {
        protected Int64 _accountNumber { get; set; }
        protected double _balance { get; set; }
        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
    }
    public class SavingsAccount : BankAccount
    {
        public double InterestRate { get; private set; }
        public SavingsAccount(Int64 accountNumber, double initialBalance, double interestRate)
        {
            _accountNumber = accountNumber;
            _balance = initialBalance;
            InterestRate = interestRate;
        }
        public override void Deposit(double amount)
        {
            _balance += amount;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Successfully Deposited {amount} into Savings Account.");
            Console.WriteLine($"Current balance : {_balance}");
            Console.ForegroundColor = ConsoleColor.White;
        }



        public override void Withdraw(double amount)
        {
            if (amount > _balance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient balance in Saving Account.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                _balance -= amount;
                Console.WriteLine($"Your Account number is : {_accountNumber}");
                Console.WriteLine($"{amount} is withdrawn from {_accountNumber}");
                Console.WriteLine($"Your current balance is : {_balance}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
    public class CheckingAccount : BankAccount
    {
        public double OverdraftLimit { get; private set; }

        public CheckingAccount(Int64 accountNumber, double initialBalance, double overdraftLimit)
        {
            _accountNumber = accountNumber;
            _balance = initialBalance;
            OverdraftLimit = overdraftLimit;
        }
        public override void Deposit(double amount)
        {
            _balance += amount;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Successfully Deposited {amount} into Checking Account.");
            Console.WriteLine($"Current balance: {_balance}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public override void Withdraw(double amount)
        {
            if (amount > _balance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient balance in Checking Account.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (amount > OverdraftLimit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You can't withdraw more than {OverdraftLimit} from Checking Account.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                _balance -= amount;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Withdrew {amount} from Checking Account.");
                Console.WriteLine($"Current balance: {_balance}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
