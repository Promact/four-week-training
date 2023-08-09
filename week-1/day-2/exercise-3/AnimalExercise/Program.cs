namespace Day2_Animal
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Rocky", 3);
            Cat cat = new Cat("Jenny", 2);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Dog:");
            Console.WriteLine($"Name: {dog.Name}, Age: {dog.age}");
            dog.move();
            dog.makeSound();

            Console.WriteLine("\nCat:");
            Console.WriteLine($"Name: {cat.Name}, Age: {cat.age}");
            cat.move();
            cat.makeSound();
            Console.ReadKey();
        }
    }
}