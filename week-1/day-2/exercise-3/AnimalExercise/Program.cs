namespace AnimalExercise
{
    internal abstract class Animal
    {
        String Name;
        int Age;

        protected abstract void MakeSound();

        static void Main(string[] args)
        {
            Console.WriteLine("animals");
            List<Animal> animals = new List<Animal>();

            Dog dog = new Dog { Name = "abc", Age = 4 };
            Dog dog2 = new Dog { Name = "kkk", Age = 5 };
            Cat cat = new Cat { Name = "ppp", Age = 6 };
            Cat cat2 = new Cat { Name = "ppp", Age = 6 };

            animals.Add(dog);
            animals.Add(dog2);
            animals.Add(cat);
            animals.Add(cat2);

            foreach (var animal in animals)
            {
                Console.WriteLine("Name:" + animal.Name + " Age:" + animal.Age);
                animal.MakeSound();

                if (animal is Imovable movable)
                {
                    movable.move();

                }
            }


        }
    }

    class Dog : Animal, Imovable
    {
        protected override void MakeSound()
        {
            Console.WriteLine("woof");
        }
        public void move()
        {
            Console.WriteLine("dog is moving");
        }

    }
    class Cat : Animal, Imovable
    {
        protected override void MakeSound()
        {
            Console.WriteLine("Meow");
        }
        public void move()
        {
            Console.WriteLine("cat is moving");
        }

    }
    interface Imovable
    {
        public void move();
    }
}

