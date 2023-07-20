using System;
namespace Excercise
{
    enum DuckType
    {
        Rubber,
        Mallard,
        Redhead
    }

    interface IDuck
    {
        double Weight { get; set; }
        int NumberOfWings { get; set; }
        DuckType Type { get; set; }

        void Fly();
        void Quack();
        void ShowDetails();
    }

    class RubberDuck : IDuck
    {
        public double Weight { get; set; }
        public int NumberOfWings { get; set; }
        public DuckType Type { get; set; } = DuckType.Rubber;

        public void Fly()
        {
            Console.WriteLine("I'm a rubber duck. I can't fly.");
        }

        public void Quack()
        {
            Console.WriteLine("Squeak! Squeak!");
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Number of wings: {NumberOfWings}");
        }
    }

    class MallardDuck : IDuck
    {
        public double Weight { get; set; }
        public int NumberOfWings { get; set; }
        public DuckType Type { get; set; } = DuckType.Mallard;

        public void Fly()
        {
            Console.WriteLine("I'm a mallard duck. I fly fast!");
        }

        public void Quack()
        {
            Console.WriteLine("Quack! Quack! Quack!");
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Number of wings: {NumberOfWings}");
        }
    }

    class RedheadDuck : IDuck
    {
        public double Weight { get; set; }
        public int NumberOfWings { get; set; }
        public DuckType Type { get; set; } = DuckType.Redhead;

        public void Fly()
        {
            Console.WriteLine("I'm a redhead duck. I fly slow.");
        }

        public void Quack()
        {
            Console.WriteLine("Quack! Quack!");
        }

        public void ShowDetails()
        {
            Console.WriteLine($"Type: {Type}");
            Console.WriteLine($"Weight: {Weight} kg");
            Console.WriteLine($"Number of wings: {NumberOfWings}");
        }
    }

    class Excercise_5
    {
        public static void Main()
        {
            // Create a rubber duck
            IDuck rubberDuck = new RubberDuck
            {
                Weight = 0.4,
                NumberOfWings = 0 // A rubber duck has no wings
            };

            // Create a mallard duck
            IDuck mallardDuck = new MallardDuck
            {
                Weight = 1.9,
                NumberOfWings = 2
            };

            // Create a redhead duck
            IDuck redheadDuck = new RedheadDuck
            {
                Weight = 2.0,
                NumberOfWings = 2
            };

            // Show the details of the ducks
            rubberDuck.ShowDetails();
            rubberDuck.Fly();
            rubberDuck.Quack();

            mallardDuck.ShowDetails();
            mallardDuck.Fly();
            mallardDuck.Quack();

            redheadDuck.ShowDetails();
            redheadDuck.Fly();
            redheadDuck.Quack();
        }
    }
}