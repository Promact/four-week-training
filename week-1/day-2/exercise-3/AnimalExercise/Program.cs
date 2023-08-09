namespace AnimalExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create a list of Animal objects, add Dog and Cat instances, and call their methods
            List<Animal> animals = new List<Animal>
            {
                new Dog { Name = "Tommy", Age = 5 },
                new Cat { Name = "Jelly", Age = 2 }
            };
            foreach (var animal in animals)
            {
                Console.WriteLine($"Name: {animal.Name}, Age: {animal.Age}");
                animal.MakeSound();
            }
        }
    }
}