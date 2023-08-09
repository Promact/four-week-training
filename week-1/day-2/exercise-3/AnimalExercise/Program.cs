namespace AnimalExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a list of Animal objects, add Dog and Cat instances, and call their methods
            String Name;
            int Age;
        protected abstract void MakeSound();

        static void Main(string[] args)
        {
            Console.WriteLine("animals");
            List<Animal> animals = new List<Animal>();

            Dog dog = new Dog { Name = "lebradog", Age = 3 };
            Dog dog2 = new Dog { Name = "bulldog", Age = 7 };
            Cat cat = new Cat { Name = "whisky", Age = 2 };
            Cat cat2 = new Cat { Name = "billi", Age = 2 };

            animals.Add(dog);
            animals.Add(dog2);
            animals.Add(cat);
            animals.Add(cat2);

            foreach (var animal in animals)
            {
                Console.WriteLine("Name:" + animal.Name + " , Age: " + animal.Age);

                animal.MakeSound();

                if (animal is IMovable movable)
                {
                    movable.move();
                }

            }
        }
    }


    class Dog : Animal, IMovable
    {
        protected override void MakeSound()
        {
            Console.WriteLine("Woof");
        }
        public void move()
        {
            Console.WriteLine("dog is moving .");
        }
    }
    class Cat : Animal, IMovable
    {
        protected override void MakeSound()
        {
            Console.WriteLine("Meow");
        }
        public void move()
        {
            Console.WriteLine("cat is moving .");
        }
    }
    interface IMovable
    {
        public void move();
    }
}
