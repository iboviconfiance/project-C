using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n=== Journal Menu ===");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Delete an entry");
            Console.WriteLine("6. Search entries by date");
            Console.WriteLine("7. Quit");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();

                    Entry newEntry = new Entry(prompt, response);
                    journal.AddEntry(newEntry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    Console.WriteLine("Entries:");
                    journal.DisplayAllWithIndex();
                    Console.Write("Enter the number of the entry to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int index))
                    {
                        journal.DeleteEntry(index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case "6":
                    Console.Write("Enter a date (ex: 9/27/2025): ");
                    string date = Console.ReadLine();
                    journal.SearchByDate(date);
                    break;

                case "7":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("⚠️ Invalid choice. Try again.");
                    break;
            }
        }
    }
}
