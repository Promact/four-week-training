namespace Day2_BankAccount
{

    public abstract class BankAccount
    {
        public String accountNo;
        public double balance;

        public BankAccount(String accountNo, double balance)
        {
            this.accountNo = accountNo;
            this.balance = balance;
        }

        public abstract void withdraw(double amount);
        public abstract void Deposit(double amount);
    }

    public class SavingAccount : BankAccount
    {
        
        public double interestRate = 7.5;

        public SavingAccount(String accountNo, double balance) : base(accountNo, balance)
        {

        }

        public override void Deposit(double amount)
        {
            balance += amount;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Updated balance after deposit in savingAccount : " + balance);

        }

        public override void withdraw(double amount)
        {
            if (amount < balance)
            {
                balance -= amount;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Updated balance after withdrawl in savingAccount: " + balance);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient funds in your account");
            }
        }

    }

    public class CheckingAccount : BankAccount
    {
        public double overDraftLimit = 10000;

        public CheckingAccount(String accountNo, double balance) : base(accountNo, balance)
        {

        }

        public override void Deposit(double amount)
        {
            balance += amount;
            Console.WriteLine("Updated balance after deposit checkingAccount: " + balance);

        }

        public override void withdraw(double amount)
        {
            if (amount < balance && amount < overDraftLimit)
            {
                balance -= amount;
                Console.WriteLine("Updated balance after withdrawl in checkingAccount : " + balance);

            }
            else if (amount > overDraftLimit)
            {
                Console.WriteLine("Amount greater than overDraftLimit");
            }
            else
                Console.WriteLine("Insufficient funds in your account");
        }

    }

}
