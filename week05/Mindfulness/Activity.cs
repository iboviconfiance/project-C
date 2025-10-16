using System;
using System.Threading;

namespace Mindfulness
{
    public abstract class Activity
    {
        // Private fields (encapsulation)
        private string _name;
        private string _description;
        private int _durationInSeconds;

        // Protected properties for derived classes
        protected string Name => _name;
        protected string Description => _description;
        protected int Duration => _durationInSeconds;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
            _durationInSeconds = 0;
        }

        // Common method to configure duration
        public void ConfigureDuration()
        {
            Console.Clear();
            Console.WriteLine($"--- {Name} ---");
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
            Console.Write("Enter the duration of the activity in seconds (e.g., 30): ");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int seconds) && seconds > 0)
                {
                    _durationInSeconds = seconds;
                    break;
                }
                Console.Write("Please enter a valid number of seconds: ");
            }
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"--- {Name} ---");
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Great job!");
            Console.WriteLine($"You have completed: {Name} for {Duration} seconds.");
            ShowSpinner(3);
            Console.WriteLine();
        }

        // Animation: spinner (duration in seconds)
        protected void ShowSpinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            DateTime end = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            while (DateTime.Now < end)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(250);
                Console.Write("\b \b"); // erase
                i++;
            }
        }

        // Animation: countdown from number of seconds (displays numbers)
        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        // Every activity must implement Run
        public abstract void Run();
    }
}
