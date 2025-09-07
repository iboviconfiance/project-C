using System;

class Program
{
    static void Main(string[] args)
    {
        int grade;
        string letter;

        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        grade = int.Parse(input);

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your letter grade is: {letter}");

        // Step 5: Display pass/fail message
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep trying! You can do better next time.");
        }

        // Step 6: Optional stretch challenge - + and -
        string sign = "";

        if (letter != "F" && letter != "A")
        {
            int lastDigit = grade % 10;
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        Console.WriteLine($"Your letter grade with sign is: {letter}{sign}");
    
    }
}