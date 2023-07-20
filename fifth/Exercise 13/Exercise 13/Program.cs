using System;
using System.Collections.Generic;

public static class CustomExtensions
{
    public static bool CustomAll<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (T item in source)
        {
            if (!predicate(item))
            {
                return false;
            }
        }
        return true;
    }

    public static bool CustomAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (T item in source)
        {
            if (predicate(item))
            {
                return true;
            }
        }
        return false;
    }

    public static T CustomMax<T>(this IEnumerable<T> source, Func<T, IComparable> selector)
    {
        T max = default(T);
        foreach (T item in source)
        {
            if (max == null || selector(item).CompareTo(selector(max)) > 0)
            {
                max = item;
            }
        }
        return max;
    }

    public static T CustomMin<T>(this IEnumerable<T> source, Func<T, IComparable> selector)
    {
        T min = default(T);
        foreach (T item in source)
        {
            if (min == null || selector(item).CompareTo(selector(min)) < 0)
            {
                min = item;
            }
        }
        return min;
    }

    public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (T item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<TResult> CustomSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        foreach (TSource item in source)
        {
            yield return selector(item);
        }
    }

    public static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        // CustomAll example
        bool allEven = numbers.CustomAll(n => n % 2 == 0);
        Console.WriteLine($"All even? {allEven}");

        // CustomAny example
        bool anyEven = numbers.CustomAny(n => n % 2 == 0);
        Console.WriteLine($"Any even? {anyEven}");

        // CustomMax example
        int maxNumber = numbers.CustomMax(n => n);
        Console.WriteLine($"Max number: {maxNumber}");

        // CustomMin example
        int minNumber = numbers.CustomMin(n => n);
        Console.WriteLine($"Min number: {minNumber}");

        // CustomWhere example
        IEnumerable<int> oddNumbers = numbers.CustomWhere(n => n % 2 != 0);
        Console.Write("Odd numbers: ");
        foreach (int number in oddNumbers)
        {
            Console.Write($"{number} ");
        }
        Console.WriteLine();

        // CustomSelect example
        IEnumerable<int> squaredNumbers = numbers.CustomSelect(n => n * n);
        Console.Write("Squared numbers: ");
        foreach (int number in squaredNumbers)
        {
            Console.Write($"{number} ");
        }
        Console.WriteLine();
    }
}