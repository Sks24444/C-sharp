using System;
using System.Collections.Generic;

namespace Ex4._2
{

    class Program
    {
        class PriorityQueue<T> where T : IEquatable<T>
        {
            private class PriorityNode
            {
                public int Priority { get; private set; }
                public T Data { get; private set; }

                public PriorityNode(int priority, T data)
                {
                    Priority = priority;
                    Data = data;
                }
            }

            private IList<PriorityNode> elements;

            public PriorityQueue()
            {
                elements = new List<PriorityNode>();
            }

            public PriorityQueue(IDictionary<int, IList<T>> elements) : this()
            {
                foreach (var kvp in elements)
                {
                    int priority = kvp.Key;
                    foreach (var item in kvp.Value)
                    {
                        Enqueue(priority, item);
                    }
                }
            }

            public int Count
            {
                get { return elements.Count; }
            }

            public bool Contains(T item)
            {
                foreach (PriorityNode node in elements)
                {
                    if (node.Data.Equals(item))
                    {
                        return true;
                    }
                }
                return false;
            }

            public void Enqueue(int priority, T item)
            {
                PriorityNode node = new PriorityNode(priority, item);
                int index = 0;
                while (index < elements.Count && node.Priority >= elements[index].Priority)
                {
                    index++;
                }
                elements.Insert(index, node);
            }

            public T Peek()
            {
                if (elements.Count == 0)
                {
                    throw new InvalidOperationException("Priority queue is empty");
                }
                return elements[0].Data;
            }

            public T Dequeue()
            {
                if (elements.Count == 0)
                {
                    throw new InvalidOperationException("Priority queue is empty");
                }
                T data = elements[0].Data;
                elements.RemoveAt(0);
                return data;
            }

            private int GetHighestPriority()
            {
                if (elements.Count == 0)
                {
                    throw new InvalidOperationException("Priority queue is empty");
                }
                return elements[0].Priority;
            }
        }
        static void Main(string[] args)
        {
            // Create a new priority queue
            PriorityQueue<string> queue = new PriorityQueue<string>();

            // some items with different priorities in Enqueue
            queue.Enqueue(1, "Buy Vegitable");
            queue.Enqueue(2, "Pay bills");
            queue.Enqueue(1, "By car");
            queue.Enqueue(3, "Complete Work");

            // Print the number of elements in the queue
            Console.WriteLine("Queue contains {0} elements", queue.Count);

            // Check if an item is in the queue
            bool hasItem = queue.Contains("Pay bills");
            Console.WriteLine("Queue contains 'Pay bills': {0}", hasItem);

            bool hasitem = queue.Contains("Buy Vegitable");
            Console.WriteLine("Queue Contains 'Buy Vegitable': {0}", hasitem);

            // Peek and dequeue items from the queue
            string firstItem = queue.Peek();
            Console.WriteLine("First item in queue: {0}", firstItem);

            while (queue.Count > 0)
            {
                string item = queue.Dequeue();
                Console.WriteLine("Dequeued item: {0}", item);
            }

            // Create  priority queue from a dictionary of elements
            IDictionary<int, IList<string>> dict = new Dictionary<int, IList<string>>();
            dict.Add(2, new List<string> { "Do laundry", "Clean kitchen" });
            dict.Add(1, new List<string> { "Read book" });
            PriorityQueue<string> queue2 = new PriorityQueue<string>(dict);

            // Print the number of elements in the second queue
            Console.WriteLine("Second queue contains {0} elements", queue2.Count);

            // Peek and dequeue items from the second queue
            string firstItem2 = queue2.Peek();
            Console.WriteLine("First item in second queue: {0}", firstItem2);

            while (queue2.Count > 0)
            {
                string item = queue2.Dequeue();
                Console.WriteLine("Dequeued item from second queue: {0}", item);
            }

            Console.ReadKey();
        }
    }
}