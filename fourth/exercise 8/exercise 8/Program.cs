using System;
using System.Collections.Generic;
namespace ex4
{
    class PriorityQueue<T> where T : IEquatable<T>
    {
        private IDictionary<int, IList<T>> elements;

        public PriorityQueue()
        {
            elements = new Dictionary<int, IList<T>>();
        }

        public PriorityQueue(IDictionary<int, IList<T>> elements) : this()
        {
            foreach (KeyValuePair<int, IList<T>> kvp in elements)
            {
                foreach (T item in kvp.Value)
                {
                    Enqueue(kvp.Key, item);
                }
            }
        }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (IList<T> list in elements.Values)
                {
                    count += list.Count;
                }
                return count;
            }
        }

        public bool Contains(T item)
        {
            foreach (IList<T> list in elements.Values)
            {
                if (list.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void Enqueue(int priority, T item)
        {
            if (!elements.ContainsKey(priority))
            {
                elements[priority] = new List<T>();
            }
            elements[priority].Add(item);
        }

        public T Dequeue()
        {
            int priority = GetHighestPriority();
            IList<T> list = elements[priority];
            T item = list[0];
            list.RemoveAt(0);
            if (list.Count == 0)
            {
                elements.Remove(priority);
            }
            return item;
        }

        public T Peek()
        {
            int priority = GetHighestPriority();
            IList<T> list = elements[priority];
            return list[0];
        }

        private int GetHighestPriority()
        {
            int highestPriority = int.MinValue;
            foreach (int priority in elements.Keys)
            {
                if (priority > highestPriority)
                {
                    highestPriority = priority;
                }
            }
            return highestPriority;
        }
    }

    class Program
    {
        static void Main()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>();
            queue.Enqueue(5, "grapes");
            queue.Enqueue(3, "pineapple");
            queue.Enqueue(7, "guava");
            queue.Enqueue(8, "apple");
            queue.Enqueue(2, "orange");
            queue.Enqueue(9, "flower");


            // to check fruit is available in queue
            Console.WriteLine("Enter Any Fruit Name");
            string fruit = Console.ReadLine();
            Console.WriteLine("Contains item " + fruit + "? " + queue.Contains(fruit));

            Console.WriteLine("Count: " + queue.Count);

            Console.WriteLine("Items in queue:");
            while (queue.Count > 0)
            {
                string item = queue.Dequeue();
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}