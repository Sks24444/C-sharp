using System;

class FirstAssignment
{
    static void Main(string[] args)
    {

        // Convert input using int.parse
        Console.Write("Enter an integer (using int.Parse): ");
        string inputString = Console.ReadLine();
        int parsedInt = int.Parse(inputString);
        Console.WriteLine($"Parsed integer: {parsedInt}");

        // Convert input using Convert.ToInt
        Console.Write("Enter a integer (using Convert.ToInt): ");
        inputString = Console.ReadLine();
        int convertedInt = Convert.ToInt32(inputString);
        Console.WriteLine($"Converted integer: {convertedInt}");

        // Convert input int.TryParse
        Console.Write("Enter a integer (using int.TryParse): ");
        inputString = Console.ReadLine();
        int tryParsedInt;
        bool isInt = int.TryParse(inputString, out tryParsedInt);
        if (isInt)
        {
            Console.WriteLine($"Try-parsed integer: {tryParsedInt}");
        }
        else
        {
            Console.WriteLine("Invalid input. Could not parse ");
        }

        // Convert input  float using float.Parse
        Console.Write("Enter a float- point number (using float.Parse):");
        inputString = Console.ReadLine();
        float parsedFloat = float.Parse(inputString);
        Console.WriteLine($"Parsed float: {parsedFloat}");

        // Convert input  float by using convert.Tosingle
        Console.Write("Enter a float point number (using convert.To.Single):");
        inputString = Console.ReadLine();
        float convertedFloat = Convert.ToSingle(inputString);
        Console.WriteLine($"Converted float: {convertedFloat}");

        // convert input using bool.Parse
        Console.Write("Enter a bool value (using bool.Parse): ");
        inputString = Console.ReadLine();
        bool parsedBool = bool.Parse(inputString);
        Console.WriteLine($"Parsed boolean: {parsedBool}");

        // Convert input using Convert.ToBoolean
        Console.Write("Enter a bool value (using Convert.ToBoolean): ");
        inputString = Console.ReadLine();
        bool convertedBool = Convert.ToBoolean(inputString);
        Console.WriteLine($"Converted boolean: {convertedBool}");

        //Convert input using bool.TryParse
        Console.Write("Enter a bool value (using bool.TryParse): ");
        inputString = Console.ReadLine();
        bool tryParsedBool;
        bool isBool = bool.TryParse(inputString, out tryParsedBool);
        if (isBool)
        {
            Console.WriteLine($"Try-parsed boolean: {tryParsedBool}");
        }
        else
        {
            Console.WriteLine("Invalid input. Could not parse to bool.");
        }
    }
}
