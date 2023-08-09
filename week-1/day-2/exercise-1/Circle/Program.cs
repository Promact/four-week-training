namespace Circle
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a Circle object and display its area and circumference
            double Radius;
            bool FirstIteration = true;
            do
            {
                if(!FirstIteration)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid number !!!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.Write("Please Enter radius : ");
                FirstIteration = false;

            } while (!double.TryParse(Console.ReadLine(), out Radius));

            // Create instance of Circle class
            Circle circleObj = new(Radius);
            
            // call GetArea() method that calculate area
            double Area = circleObj.GetArea();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Area of Circle is : {Area}");

            // call GetArea() method that calculate circumference
            double Circumference = circleObj.GetCircumference();
            Console.WriteLine($"Circumference of Cirxle is : {Circumference}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}