using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalExercise
{
    // Abstract class for animals
    public abstract class Animal
    {
        // Properties of an animal
        public string? Name; // Name of the animal (can be null)
        public int Age;      // Age of the animal

        // Abstract method for making a sound
        // The body of this method must be provided by derived classes
        public abstract void MakeSound();
    }

    // Interface for movable objects
    interface IMovable
    {
        void Move(); // Method to define movement behavior
    }

    // First derived class: Dog
    class Dog : Animal, IMovable
    {
        public override void MakeSound()
        {
            // Implementation of the MakeSound method for a dog
            Console.WriteLine("Dog Sounds - Woof Woof...");
        }

        public void Move()
        {
            // Implementation of the Move method for a dog
            Console.WriteLine("This is the Move() method.");
        }
    }

    // Second derived class: Cat
    class Cat : Animal, IMovable
    {
        public override void MakeSound()
        {
            // Implementation of the MakeSound method for a cat
            Console.WriteLine("Cat Sounds - Meow Meow...\n");
        }

        public void Move()
        {
            // Implementation of the Move method for a cat
            Console.WriteLine("This is the Move() method.");
        }
    }
}
