using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // 1. Find odd - Lambda Expression - without curly brackets
        var odds1 = numbers.Where(n => n % 2 != 0);
        Console.Write("list of Odd Number: ");
        foreach (var a in odds1)
        {
            Console.Write(a + " ");
        }
        Console.WriteLine("");
        // 2. Find even - Lambda Expression - with curly brackets
        var evens1 = numbers.Where(n => { return n % 2 == 0; });
        Console.Write("list of even number: ");
        foreach (var a in evens1)
        {
            Console.Write(a + " ");
        }
        Console.WriteLine("");
        // 3. Find prime - Anonymous Method
        var primes1 = numbers.Where(delegate (int n)
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        });
        Console.Write("list of prime number: ");
        foreach (var a in primes1)
        {
            Console.Write(a + " ");
        }
        Console.WriteLine("");
        // 4. Find prime - Another Lambda Expression
        var primes2 = numbers.Where(n =>
        {
            if (n < 2) return false;
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        });

        // 5. Find elements greater than five - Method Group Conversion Syntax
        Func<int, bool> greaterThanFive = IsGreaterThanFive;
        var greaterThanFiveNumbers = numbers.Where(greaterThanFive);

        // 6. Find less than five - Delegate Object in Where - Method Group Conversion Syntax in Constructor of Object
        // var lessThanFiveNumbers = numbers.Where(new Predicate<int>(IsLessThanFive));

        // 7. Find 3k - Delegate Object in Where - Lambda Expression in Constructor of Object
        var threeKNumbers = numbers.Where(new Func<int, bool>(n => n % 3 == 0));

        // 8. Find 3k+1 - Delegate Object in Where - Anonymous Method in Constructor of Object
        var threeKPlusOneNumbers = numbers.Where(delegate (int n)
        {
            return n % 3 == 1;
        });

        // 9. Find 3k+2 - Delegate Object in Where - Lambda Expression Assignment
        Func<int, bool> threeKPlusTwo = n => n % 3 == 2;
        var threeKPlusTwoNumbers = numbers.Where(threeKPlusTwo);

        // 10. Find anything - Delegate Object in Where - Anonymous Method Assignment
        Predicate<int> anything = delegate (int n)
        {
            return true;
        };
        //var anythingNumbers = numbers.Where(anything);

        // 11. Find anything - Delegate Object in Where - Method Group Conversion Assignment
        Func<int, bool> anything2 = delegate (int n)
        {
            return true;
        };
        var anythingNumbers2 = numbers.Where(anything2);
    }

    static bool IsGreaterThanFive(int n)
    {
        return n > 5;
    }

    static bool IsLessThanFive(int n)
    {
        return n < 5;
    }


}