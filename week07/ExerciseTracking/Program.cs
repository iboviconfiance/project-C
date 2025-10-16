using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create some activities
        Running run = new Running(new DateTime(2022, 11, 3), 30, 4.8);
        Cycling bike = new Cycling(new DateTime(2022, 11, 3), 40, 15);
        Swimming swim = new Swimming(new DateTime(2022, 11, 3), 25, 40);

        // Store all in a single list (shows polymorphism)
        List<Activity> activities = new List<Activity> { run, bike, swim };

        // Display summaries
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
