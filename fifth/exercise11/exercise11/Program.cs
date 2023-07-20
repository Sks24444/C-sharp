using System;

namespace ExtensionMethodsDemo
{
    public static class IntegerExtensions
    {
        public static bool IsOdd(this int number)
        {
            return number % 2 != 0;
        }

        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }

        public static bool IsPrime(this int number)
        {
            if (number < 2) return false;
            if (number == 2 || number == 3) return true;
            if (number % 2 == 0 || number % 3 == 0) return false;
            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsDivisibleBy(this int number, int divisor)
        {
            return number % divisor == 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int number = 8;
            Console.WriteLine($"Is {number} odd? {number.IsOdd()}");
            Console.WriteLine($"Is {number} even? {number.IsEven()}");
            Console.WriteLine($"Is {number} prime? {number.IsPrime()}");
            Console.WriteLine($"Is {number} divisible by 3? {number.IsDivisibleBy(3)}");
        }
    }
}