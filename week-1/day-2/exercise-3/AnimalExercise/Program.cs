namespace AnimalExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Create instances of Dog and Cat
            Dog dogSound = new Dog();
            Cat catSound = new Cat();

            // Call the MakeSound method for both objects
            dogSound.MakeSound();
            catSound.MakeSound();

            // Call the Move method for both objects
            dogSound.Move();
            catSound.Move();
        }
    }
}