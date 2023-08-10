namespace Day4_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please write number : ");
            int num = Convert.ToInt32(Console.ReadLine());

            Iterators itr = new Iterators();
            Console.WriteLine("Fibonacci Number : ");
            itr.fibonacci(num);

        }

        //fibonacci series method
        public void fibonacci(int n)
        {
            int t1 = 0;
            int t2 = 1;
            int next = 0;

           for(int i=1;i<=n;++i)
            {
                if (i == 1)
                {
                    Console.WriteLine(t1);
                    continue;
                }
                    
                if (i == 2)
                {
                    Console.WriteLine(t2);
                    continue;
                }

                next = t1 + t2;
                t1 = t2;
                t2 = next;

                Console.WriteLine(next);

            }
        }
    }
}