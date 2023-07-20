using System;
using System.Collections;
using System.Collections.Generic;

namespace Exercise_7
{
    class Duck
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public int NumberOfWings { get; set; }

        public Duck(string name, int weight, int numberOfWings)
        {
            Name = name;
            Weight = weight;
            NumberOfWings = numberOfWings;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Weight: {Weight}, Number of Wings: {NumberOfWings}";
        }
    }

    class DuckCollection : IEnumerable<Duck>
    {
        private List<Duck> ducks = new List<Duck>();

        public void AddDuck(Duck duck)
        {
            ducks.Add(duck);
        }

        public void RemoveDuck(Duck duck)
        {
            ducks.Remove(duck);
        }

        public void RemoveAllDucks()
        {
            ducks.Clear();
        }

        public IEnumerator<Duck> GetEnumerator()
        {
            ducks.Sort((duck1, duck2) => duck1.Weight.CompareTo(duck2.Weight));
            return ducks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<Duck> GetDucksByNumberOfWings()
        {
            ducks.Sort((duck1, duck2) => duck1.NumberOfWings.CompareTo(duck2.NumberOfWings));
            return ducks;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DuckCollection duckCollection = new DuckCollection();
            duckCollection.AddDuck(new Duck("Daffy", 5, 2));
            duckCollection.AddDuck(new Duck("Donald", 4, 2));
            duckCollection.AddDuck(new Duck("Howard", 3, 2));
            duckCollection.AddDuck(new Duck("Darkwing", 6, 2));
            duckCollection.AddDuck(new Duck("Launchpad", 2, 2));

            // Iterate the duck collection in increasing order of their weights
            foreach (Duck duck in duckCollection)
            {
                Console.WriteLine(duck);
            }

            // Iterate the duck collection in increasing order of number of wings
            foreach (Duck duck in duckCollection.GetDucksByNumberOfWings())
            {
                Console.WriteLine(duck);
            }

            duckCollection.RemoveDuck(new Duck("Darkwing", 6, 2));
            duckCollection.RemoveAllDucks();

            Console.ReadKey();
        }
    }
}