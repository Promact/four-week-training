using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalExercise
{
    internal abstract class Animal
    {
        public string Name;
        public int Age;

        public abstract void MakeSound();
    }
    class Dog : Animal, IMovable
    {
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} the dog make sound is: Woof!");
        }
        public void Move()
        {
            Console.WriteLine($"{Name} the dog is running.");
        }
    }

    class Cat : Animal, IMovable
    {
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} the cat make sound is: Meow!");
        }
        public void Move()
        {
            Console.WriteLine($"{Name} the cat is climbing.");
        }
    }

    interface IMovable
    {
        void Move();
    }
}
