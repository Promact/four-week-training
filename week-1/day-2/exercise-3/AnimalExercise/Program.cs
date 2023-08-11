namespace AnimalExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of Animal objects, add Dog and Cat instances, and call their methods

            List<Animal> animals = new List<Animal>();

            Console.WriteLine("animals", animals);
            Dog dog = new Dog
            {
                Name = "Daisy",
                Age = 1
            };

            Cat cat = new Cat
            {
                Name = "Bela",
                Age = 1
            };

            animals.Add(dog);
            animals.Add(cat);


            foreach (var animal in animals)
            {
                animal.MakeSound();
                if (animal is IMovable movableAnimal)
                {
                    movableAnimal.Move();
                }
                Console.WriteLine("Name:" + animal.Name + ", Age:" + animal.Age);
            }
            Console.ReadLine();
        }
    }
}