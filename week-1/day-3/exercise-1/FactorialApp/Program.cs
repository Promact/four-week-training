namespace FactorialApp
{
    public class Program
    {
        public static void Main()
        {
            bool FirstIterate = true;
            int number;
            do
            {
                // condition fro skip the warning message to print
                if (!FirstIterate)
                {
                    // change the red color for warning that value is not allowed
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Please Enter valid number !!!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("Please Enter number : ");
                FirstIterate = false;
                // check the condition for input it;s take only positive integer number
            } while (!int.TryParse(Console.ReadLine(), out number) || (number < 0));

            // call the calculatefactorial() method 
            long factorial = CalculateFactorial(number);

            // print that message with green colour
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The factorial of {number} is: {factorial}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static long CalculateFactorial(int number)
        {
            //throw new NotImplementedException();
            int factorial = 1;
            // it check the condition if number is 0 and 1 than retrun 1
            if (number == 0 || number == 1)
            {
                return factorial;
            }
            else
            {
                // calculate the factorial using for loop
                for (int i = 2; i <= number; i++)
                {
                    factorial *= i;
                }
            }
            return factorial;
        }
    }
}