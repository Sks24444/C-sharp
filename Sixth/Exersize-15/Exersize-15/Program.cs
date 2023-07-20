using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

public class Program
{
    static void Main(string[] args)
    {
        ObservableCollection<string> collection = new ObservableCollection<string>();
        collection.CollectionChanged += CollectionChangedEventHandler;
        // X element is added
        collection.Add("x");
        // x element is removed
        collection.Remove("x");
    }

    static void CollectionChangedEventHandler(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                Console.WriteLine($"Element '{e.NewItems[0]}' is added in collection");
                break;
            case NotifyCollectionChangedAction.Remove:
                Console.WriteLine($"Element '{e.OldItems[0]}' is removed from collection");
                break;
        }
    }
}