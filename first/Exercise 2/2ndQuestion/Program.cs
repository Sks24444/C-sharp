using System;

class Compare
{
    static void Main(string[] args)
    {
        // Create two objects with the same value
        string a1 = ("Hello");
        string b2 = ("Hello");

        // Use the  " == " operator to compare both the objects
        bool equal1 = (a1 == b2);
        Console.WriteLine($"Using == operator: {equal1}");

        // Equals method to compare both objects
        bool equal2 = a1.Equals(b2);
        Console.WriteLine($"Using Object.Equals method: {equal2}"); 
       
        // ReferenceEquals method to compare both objects
        bool equal3 = Object.ReferenceEquals(a1, b2);
        Console.WriteLine($"Using Object.ReferenceEquals method: {equal3}");
     
        // Create a new object with the same value as a1
        string c3 = "Hello, world!";

        // Use the == operator to compare a1 and c3
        bool equal4 = (a1 == c3);
        Console.WriteLine($"Using == operator: {equal4}"); 
        
        //Equals method to compare a1 and c3
        bool equal5 = a1.Equals(c3);
        Console.WriteLine($"Using Object.Equals method: {equal5}");
       
       //ReferenceEquals method to compare a1 and c3
        bool equal6 = Object.ReferenceEquals(a1, c3);
        Console.WriteLine($"Using Object.ReferenceEquals method: {equal6}");
        // Output: Using Object.ReferenceEquals method: False
    }
}