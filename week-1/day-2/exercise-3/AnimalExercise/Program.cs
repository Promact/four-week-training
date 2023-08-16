using System;
using System.Collections.Generic;

public abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

    public abstract void MakeSound();
}

public class Dog : Animal, IMovable
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof");
    }

    public void Move()
    {
        Console.WriteLine("Dog is running.");
    }
}

public class Cat : Animal, IMovable
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }

    public void Move()
    {
        Console.WriteLine("Cat is sneaking.");
    }
}

public interface IMovable
{
    void Move();
}

class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>
        {
            new Dog { Name = "Buddy", Age = 3 },
            new Cat { Name = "Whiskers", Age = 2 }
        };

        foreach (var animal in animals)
        {
            Console.WriteLine($"Name: {animal.Name}, Age: {animal.Age}");
            animal.MakeSound();

            if (animal is IMovable movableAnimal)
            {
                movableAnimal.Move();
            }

            Console.WriteLine();
        }
    }
}
