using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 💡 Bonus creativity: Library of scriptures
        List<(Reference, string)> scriptures = new List<(Reference, string)>
        {
            (new Reference("John", 3, 16),
             "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            
            (new Reference("Proverbs", 3, 5, 6),
             "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            
            (new Reference("Philippians", 4, 13),
             "I can do all things through Christ which strengtheneth me.")
        };

        // Select a random scripture
        Random rnd = new Random();
        var selected = scriptures[rnd.Next(scriptures.Count)];
        Scripture scripture = new Scripture(selected.Item1, selected.Item2);

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

        while (true)
        {
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
            {
                Console.WriteLine("\nGoodbye!");
                break;
            }

            scripture.HideRandomWords(3); // hide 3 random words per round
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are now hidden! Well done!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
        }
    }
}

/*
===============================================
CSE 210 - Week 03 Project: Scripture Memorizer
Author: Confiance Hategekimana Ibovi
===============================================

💡 EXCEEDING REQUIREMENTS:
- Supports MULTIPLE scriptures (randomly chosen)
- Handles verse ranges (e.g., Proverbs 3:5–6)
- Encapsulation with 4 well-defined classes
- Random hiding limited to visible words only
- Clean console UI (clear + redisplay)
===============================================
*/
