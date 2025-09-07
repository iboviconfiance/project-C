using System;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Declare variables
        string firstName;
        string lastName;

        // Step 2: Get user input
        Console.Write("What is your first name? ");
        firstName = Console.ReadLine();

        Console.Write("What is your last name? ");
        lastName = Console.ReadLine();

        // Step 3: Display output
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
