using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _questions;

        // To ensure no repetition until all items are used
        private Queue<string> _promptQueue;
        private Queue<string> _questionQueue;
        private Random _rand;

        public ReflectingActivity() : base(
            "Reflecting Activity",
            "This activity helps you reflect on times when you have shown strength and resilience."
        )
        {
            _rand = new Random();
            _prompts = new List<string>()
            {
                "Think about a time when you stood up for someone else.",
                "Think about a time when you did something really difficult.",
                "Think about a time when you helped someone in need.",
                "Think about a time when you did something truly selfless."
            };

            _questions = new List<string>()
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was over?",
                "What made this moment different?",
                "What is your favorite thing about this experience?",
                "What lessons can you learn from this experience?",
                "What did you learn about yourself?",
                "How can you keep this experience in mind for the future?"
            };

            RefillQueues();
        }

        private void RefillQueues()
        {
            // Shuffle and refill the queues
            _promptQueue = new Queue<string>(ShuffleList(_prompts));
            _questionQueue = new Queue<string>(ShuffleList(_questions));
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
            if (_promptQueue.Count == 0) RefillQueues();
            return _promptQueue.Dequeue();
        }

        private string GetRandomQuestion()
        {
            if (_questionQueue.Count == 0) RefillQueues();
            return _questionQueue.Dequeue();
        }

        public override void Run()
        {
            ConfigureDuration();
            DisplayStartingMessage();

            string prompt = GetRandomPrompt();
            Console.WriteLine();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine($"-- {prompt}");
            Console.WriteLine();
            Console.WriteLine("Press Enter when you are ready to begin reflecting...");
            Console.ReadLine();

            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(Duration);

            while (DateTime.Now < end)
            {
                string question = GetRandomQuestion();
                Console.WriteLine($"> {question}");
                ShowSpinner(5); // shows spinner for 5 seconds while reflecting

                Console.WriteLine();
            }

            DisplayEndingMessage();

            // Log
            Logger.AppendLog(Name, Duration);
        }
    }
}
