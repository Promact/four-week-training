using System;

public abstract class BankAccount
{
    public string AccountNumber { get; protected set; }
    public double Balance { get; protected set; }

    public BankAccount(string accountNumber, double initialBalance)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public abstract void Deposit(double amount);
    public abstract void Withdraw(double amount);
}

public class SavingsAccount : BankAccount
{
    public double InterestRate { get; private set; }

    public SavingsAccount(string accountNumber, double initialBalance, double interestRate)
        : base(accountNumber, initialBalance)
    {
        InterestRate = interestRate;
    }

    public override void Deposit(double amount)
    {
        Balance += amount;
    }

    public override void Withdraw(double amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }
}

public class CheckingAccount : BankAccount
{
    public double OverdraftLimit { get; private set; }

    public CheckingAccount(string accountNumber, double initialBalance, double overdraftLimit)
        : base(accountNumber, initialBalance)
    {
        OverdraftLimit = overdraftLimit;
    }

    public override void Deposit(double amount)
    {
        Balance += amount;
    }

    public override void Withdraw(double amount)
    {
        if (Balance + OverdraftLimit >= amount)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        SavingsAccount savingsAccount = new SavingsAccount("SA123", 1000, 0.05);
        CheckingAccount checkingAccount = new CheckingAccount("CA456", 500, 200);

        savingsAccount.Deposit(500);
        savingsAccount.Withdraw(200);

        checkingAccount.Deposit(300);
        checkingAccount.Withdraw(800);

        Console.WriteLine($"Savings Account Balance: {savingsAccount.Balance}");
        Console.WriteLine($"Checking Account Balance: {checkingAccount.Balance}");
    }
}
