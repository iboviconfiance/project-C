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
            Console.WriteLine("\n=== Log Menu ===");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Print the log");
            Console.WriteLine("3. Save the log to a file");
            Console.WriteLine("4. Load log from file");
            Console.WriteLine("5. Exit");
            Console.Write("your choice: ");
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
                    Console.Write("Name of the file to store: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Name of the file to upload: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("⚠️ Invalid choice. Try again.");
                    break;
            }
        }
    }
}
