using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    // Abstract class
    public abstract class BankAccount
    {
        // Properties 
        public long AccountNumber; // The account number associated with the bank account.
        public double Balance;     // The current balance in the bank account.

        // Methods
        public abstract void Deposit(double amount); // Abstract method to deposit money into the account.
        public abstract void Withdraw(double amount); // Abstract method to withdraw money from the account.
    }

    // First Derived class
    class SavingsAccount : BankAccount
    {
        private double InterestRate; // The interest rate for the savings account.

        // Constructor to initialize the savings account.
        public SavingsAccount(long accountNumber, double balance, double interestRate)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            InterestRate = interestRate;
        }

        // Deposit method for savings account.
        public override void Deposit(double amount)
        {
            Balance += amount;
        }

        // Withdraw method for savings account.
        public override void Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine($"Insufficient Balance. Your Main Balance is {Balance}");
            }
        }
    }

    // Second Derived class
    class CheckingAccount : BankAccount
    {
        private double OverdraftLimit; // The overdraft limit for the checking account.

        // Constructor to initialize the checking account.
        public CheckingAccount(long accountNumber, double balance, double overdraftLimit)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            OverdraftLimit = overdraftLimit;
        }

        // Deposit method for checking account.
        public override void Deposit(double amount)
        {
            Balance += amount;
        }

        // Withdraw method for checking account.
        public override void Withdraw(double amount)
        {
            if (amount <= OverdraftLimit + Balance)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Exceed the limit of withdrawn for existing balance and overdraft limit.");
            }
        }
    }
}
