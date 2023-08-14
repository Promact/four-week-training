namespace BankAccount
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

{
    public abstract class BankAccount
    {
        protected Int64 AccountNumber = 326002120001175;
        public Int32 Balance = 30000;

        protected abstract void Deposit();
        protected abstract void Withdraw();
        static void Main(string[] args)
        {
            Console.WriteLine("bank account");

            CheckingAccount account = new CheckingAccount();

            account.Withdraw();
            account.Deposit();

            SavingsAccount savingsAccount = new SavingsAccount();
            savingsAccount.Withdraw();
            savingsAccount.Deposit();
        }
    }

    public class CheckingAccount : BankAccount
    {
        private int OverdraftLimit = 10000;
        public Int32 Checkbalance;
        public CheckingAccount()
        {
            Checkbalance = Balance;
            Console.WriteLine("Account Balance is" + Checkbalance);

        }
        protected override void Deposit()
        {

            Console.WriteLine("how much you want to Deposit In current account");
            Int32 Money = Convert.ToInt32(Console.ReadLine());
            Boolean flg = false;
            if (OverdraftLimit >= Money)
            {
                Checkbalance = Checkbalance + Money;
                flg = true;
            }
            else
            {
                flg = false;
            }
            if (flg)
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your Deposit sucessful!! ");
                Console.ResetColor();
                Console.WriteLine("Your current account balance is " + Checkbalance);
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your Deposit failed!!  ");
                Console.ResetColor();
            }
        }
        protected override void Withdraw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("how much you want to withdraw from current account");
            Console.ResetColor();
            Int32 Money = Convert.ToInt32(Console.ReadLine());
            Boolean flag = false;
            if (OverdraftLimit >= Money)
            {
                flag = true;
                Checkbalance = Checkbalance - Money;
            }
            else
            {
                flag = false;
            }
            if (flag)
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("WITHDRAW SUCESSFUL !! ");
                Console.ResetColor();
                Console.WriteLine("Your current account balance is " + Checkbalance);
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WITHDRAW failed  !! "); Console.ResetColor();
            }
        }
    }
    class SavingsAccount : BankAccount
    {
        private int InterestRate;
        private int OverdraftLimits = 10000;
        public Int32 Checkbal;
        public SavingsAccount()
        {
            Checkbal = Balance;
        }
        protected override void Deposit()
        {
            Console.WriteLine("how much you want to Deposit In saving account");
            int Money = Convert.ToInt32(Console.ReadLine());
            Boolean flg = false;
            if (OverdraftLimits >= Money)
            {
                flg = true;
                Checkbal = Checkbal + Money;
            }
            else
            {
                flg = false;
            }
            if (flg)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your Deposit sucessful!! "); Console.ResetColor();
                Console.WriteLine("Your current account balance is " + Checkbal);
            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your Deposit failed !!"); Console.ResetColor();
            }
        }
        protected override void Withdraw()
        {
            Console.WriteLine("how much you want to withdraw In saving account");
            int Money = Convert.ToInt32(Console.ReadLine());
            bool flg = false;
            if (OverdraftLimits >= Money)
            {
                flg = true;
                Checkbal = Checkbal - Money;
            }
            else
            {
                flg = false;
            }
            if (flg)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("withdraw sucessful!!"); Console.ResetColor();
                Console.WriteLine("Your current account balance is " + Checkbal);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WITHDRAW failed  !! "); Console.ResetColor();
            }
        }
    }

}
