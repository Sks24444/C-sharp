using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime_no
{
    public class Question3
    {
        public static void Main()
        {
            try {
                Console.WriteLine("Enter first Integer:");
                //here simply read input as a string
                string input_from_user = Console.ReadLine();
                int start = int.Parse(input_from_user);

                Console.WriteLine("Enter first Integer:");
                string input_from_user1 = Console.ReadLine();
                int end = int.Parse(input_from_user1);

                if (start <= 2 || end >1000)
                {
                    Console.WriteLine("please type valid input ");
                }
                else
                {
                    for(int i = start; i <= end; i++) 
                    {
                        bool isPrime = true;
                        for(int j=2;j<=Math.Sqrt(i);j++)
                        {
                            if(i%j == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                        if(isPrime) 
                        {
                            Console.WriteLine(i);
                        }
                    }
                    Console.ReadLine();
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("invalid input");
            }
        }
        
    }
}