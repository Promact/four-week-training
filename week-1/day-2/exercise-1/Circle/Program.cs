namespace Day2_task1
{
      internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please write raduis of circle : ");

                double radius = double.Parse(Console.ReadLine());
                Circle circle = new Circle(radius);

                if (radius < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please write radius in positive number");
                    continue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Area of circle is : " + circle.getArea(radius));
                    Console.WriteLine("Circumference of circle is : " + circle.getCircumference(radius));
                    break;

                }
            }


        }
    }
}