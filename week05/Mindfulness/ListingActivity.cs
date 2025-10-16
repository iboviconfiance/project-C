using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts;
        private Queue<string> _promptQueue;
        private Random _rand;

        public ListingActivity() : base(
            "Listing Activity",
            "This activity helps you reflect on the good things in your life by listing as many items as you can in a specific category."
        )
        {
            _rand = new Random();
            _prompts = new List<string>()
            {
                "Who are people you appreciate?",
                "What are some of your personal strengths?",
                "Who are people you have helped this week?",
                "When have you felt the Holy Spirit this month?",
                "Who are some of your personal heroes?"
            };

            RefillQueue();
        }

        private void RefillQueue()
        {
            _promptQueue = new Queue<string>(ShuffleList(_prompts));
        }

        private List<string> ShuffleList(List<string> list)
        {
            var copy = new List<string>(list);
            for (int i = copy.Count - 1; i > 0; i--)
            {
                int j = _rand.Next(i + 1);
                var tmp = copy[i];
                copy[i] = copy[j];
                copy[j] = tmp;
            }
            return copy;
        }

        private string GetRandomPrompt()
        {
            if (_promptQueue.Count == 0) RefillQueue();
            return _promptQueue.Dequeue();
        }

        public override void Run()
        {
            ConfigureDuration();
            DisplayStartingMessage();

            string prompt = GetRandomPrompt();
            Console.WriteLine();
            Console.WriteLine("List as many responses as you can for:");
            Console.WriteLine($"-- {prompt}");
            Console.WriteLine();
            Console.WriteLine("You’ll have a few seconds to think...");
            ShowCountDown(5);
            Console.WriteLine();
            Console.WriteLine($"Start typing your items. You have {Duration} seconds. (Press Enter on an empty line to finish early)");
            
            var items = new List<string>();

            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(Duration);

            while (DateTime.Now < end)
            {
                // Note: Console.ReadLine() blocks input; we check the time before accepting more items.
                Console.Write("> ");
                string line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    break;
                }
                items.Add(line.Trim());
            }

            Console.WriteLine();
            Console.WriteLine($"You entered {items.Count} items:");
            foreach (var it in items)
            {
                Console.WriteLine($"- {it}");
            }

            DisplayEndingMessage();

            // Log with number of items
            Logger.AppendLog(Name, Duration, extra: $"ItemsCount={items.Count}");
        }
    }
}
