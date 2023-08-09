using AnimalExercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalExercise
{
    public abstract class Animal
    {
        public string? Name { get; set; }
        public int Age { get; set; }

        public abstract void MakeSound();
    }
    class Cat : Animal, IMovable
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }

        public void Move()
        {
            Console.WriteLine("Cat is climbing.");
        }
    }

    public class Dog : Animal, IMovable
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof");
        }

        public void Move()
        {
            Console.WriteLine("Dog is moving.");
        }
    }
}
