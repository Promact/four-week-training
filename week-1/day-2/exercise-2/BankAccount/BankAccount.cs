using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public abstract class BankAccount
    {
        public Int32 AccountNumber;
        public double Balance;

        public BankAccount(Int32 accountNumber, double initBalance)
        {
            AccountNumber = accountNumber;
            Balance = initBalance;
        }

        public abstract void Deposit(double amt);
        public abstract void Withdraw(double amt);

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: {Balance}");
        }
    }

    public class SavingsAccount : BankAccount
    {
        public double InterestRate;
        public SavingsAccount(Int32 accountNumber, double initBalance, double interestRate) : base(accountNumber, initBalance)
        {
            InterestRate = interestRate;
            AccountNumber = accountNumber;
            Balance = initBalance;
        }

        public override void Deposit(double amt)
        {
            if (amt > 0)
            {
                Balance += amt;
                Console.WriteLine($"Deposited: {amt}");
                Console.WriteLine($"Current Balance: {Balance}");
            }
            else
            {
                Console.WriteLine($"Invalid Deposit amount");
            }
        }

        public override void Withdraw(double amt)
        {
            if (amt > Balance || amt < 0)
            {
                Console.WriteLine($"Invalid Withdraw amount");

            }
            else
            {
                Balance -= amt;
                Console.WriteLine($"Withdraw: {amt}");
                Console.WriteLine($"Current Balance: {Balance}");
            }
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"InterestRate: {InterestRate}");
        }
    }

    class CheckingAccount : BankAccount
    {
        public double OverdraftLimit;
        public CheckingAccount(Int32 accountNumber, double initBalance, double overdraftLimit) : base(accountNumber, initBalance)
        {
            OverdraftLimit = overdraftLimit;
        }
        public override void Deposit(double amt)
        {
            if (amt > 0)
            {
                Balance += amt;
                Console.WriteLine($"Deposited: {amt}");
                Console.WriteLine($"Current Balance: {Balance}");
            }
            else
            {
                Console.WriteLine($"Invalid Deposit amount");
            }
        }

        public override void Withdraw(double amt)
        {
            if (amt > Balance || amt < 0)
            {
                Balance -= amt;
                Console.WriteLine($"Withdraw: {amt}");
                Console.WriteLine($"Current Balance: {Balance}");

            }
            else
            {
                Console.WriteLine("Invalid withdraw amount");
            }
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Overdraft Limit: {OverdraftLimit}");
        }
    }
}
