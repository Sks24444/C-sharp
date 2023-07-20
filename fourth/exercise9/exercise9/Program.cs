using System;
using System.Collections.Generic;


namespace Ex4._1
{

    interface IPriority
    {
        int Priority { get; }
    }
    class MyItem : IEquatable<MyItem>, IPriority
    {
        public string Name { get; set; }
        public int Priority { get; set; }

        public MyItem(string name, int priority)
        {
            Name = name;
            Priority = priority;
        }

        public bool Equals(MyItem other)
        {
            if (other == null) return false;
            return (Name.Equals(other.Name) && Priority.Equals(other.Priority));
        }
    }

    class Program
    {
        class PriorityQueue2<T> where T : IEquatable<T>, IPriority
        {
            private IDictionary<int, IList<T>> elements;

            public PriorityQueue2()
            {
                elements = new Dictionary<int, IList<T>>();
            }

            public PriorityQueue2(IEnumerable<T> elements) : this()
            {
                foreach (T item in elements)
                {
                    Enqueue(item);
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

            public void Enqueue(T item)
            {
                int priority = item.Priority;
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
        static void Main(string[] args)
        {
            // Create a new priority queue and add some items to it
            PriorityQueue2<MyItem> queue = new PriorityQueue2<MyItem>();
            queue.Enqueue(new MyItem("Item 1", 3));
            queue.Enqueue(new MyItem("Item 2", 1));
            queue.Enqueue(new MyItem("Item 3", 2));
            queue.Enqueue(new MyItem("Item 4", 0));

            // Print out the number of items in the queue
            Console.WriteLine("Count: " + queue.Count);

            // Print out whether the queue contains a particular item
            MyItem item = new MyItem("Item 2", 1);
            Console.WriteLine("Contains item " + item.Name + "? " + queue.Contains(item));

            // Print out the item at the front of the queue
            Console.WriteLine("Peek: " + queue.Peek().Name);

            // Remove the item at the front of the queue
            MyItem dequeuedItem = queue.Dequeue();
            Console.WriteLine("Dequeued item: " + dequeuedItem.Name);

            // Print out the item at the front of the queue again
            Console.WriteLine("Peek: " + queue.Peek().Name);
        }
    }
}