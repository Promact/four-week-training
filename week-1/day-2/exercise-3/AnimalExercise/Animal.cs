using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_Animal
{
    public interface Imovable
    {
        public void move();
    }

    public abstract class Animal
    {
        public String Name { get; set; }
        public int age { get; set; }

        public Animal(String name, int age)
        {
            this.Name = name;
            this.age = age;
        }

        public abstract void makeSound();

    }

    public class Dog : Animal, Imovable
    {
        public Dog(String name, int age) : base(name, age)
        {

        }

        public override void makeSound()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Dog sounds like Woof");
        }

        public void move()
        {
            Console.WriteLine("Dog is running");
        }

    }

    public class Cat : Animal
    {
        public Cat(String name, int age) : base(name, age)
        {

        }

        public override void makeSound()
        {
            Console.WriteLine("Cat sounds like Meow");
        }

        public void move()
        {
            Console.WriteLine("Cat is walking");
        }

    }
}
