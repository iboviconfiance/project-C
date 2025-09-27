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
            Console.WriteLine("\n=== Menu Journal ===");
            Console.WriteLine("1. Écrire une nouvelle entrée");
            Console.WriteLine("2. Afficher le journal");
            Console.WriteLine("3. Sauvegarder le journal dans un fichier");
            Console.WriteLine("4. Charger le journal depuis un fichier");
            Console.WriteLine("5. Quitter");
            Console.Write("Votre choix: ");
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
                    Console.Write("Nom du fichier à sauvegarder: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Nom du fichier à charger: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("⚠️ Choix invalide. Essayez encore.");
                    break;
            }
        }
    }
}
