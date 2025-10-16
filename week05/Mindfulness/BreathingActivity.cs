using System;
using System.Threading;

namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        // Example: duration of inhale/exhale in seconds (can be adjusted)
        private int _breathSegment = 4;

        public BreathingActivity() : base(
            "Breathing Activity",
            "This activity helps you relax by guiding you through slow breathing in and out. " +
            "Listen to your breathing and stay focused."
        )
        { }

        public override void Run()
        {
            ConfigureDuration();
            DisplayStartingMessage();

            DateTime start = DateTime.Now;
            DateTime end = start.AddSeconds(Duration);

            while (DateTime.Now < end)
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(_breathSegment);
                Console.WriteLine(); // newline after countdown erase

                if (DateTime.Now >= end) break;

                Console.WriteLine("Breathe out...");
                ShowCountDown(_breathSegment);
                Console.WriteLine();

                // small delay between cycles for readability
                Thread.Sleep(300);
            }

            DisplayEndingMessage();

            // Log
            Logger.AppendLog(Name, Duration);
        }
    }
}
