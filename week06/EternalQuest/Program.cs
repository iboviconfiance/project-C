using System;

/*
 Showing Creativity & Exceeding Requirements:
 - Leveling system: player levels up every 1000 points (simple but demonstrative).
 - Badges: awarded on first interaction with a goal and on milestones (e.g., Habit Builder at 500 points).
 - Save/Load persists score, level, badges and all goals.
 - Design is extensible: new Goal subclasses (NegativeGoal, ProgressGoal) can be added without changing manager code.
 - These additions are documented here as required by the assignment.
*/

class Program
{
    static void Main(string[] args)
    {
        var manager = new GoalManager();
        // Try to auto-load default save file if exists
        const string DEFAULT_SAVE = "goals.txt";
        if (System.IO.File.Exists(DEFAULT_SAVE))
        {
            manager.LoadGoals(DEFAULT_SAVE);
        }

        // Start interactive menu (Start method implemented in GoalManager)
        manager.Start();

        // On exit auto-save
        Console.Write("Save before exit? (Y/n): ");
        var c = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(c) || c.Trim().ToLower() == "y")
        {
            manager.SaveGoals(DEFAULT_SAVE);
        }

        Console.WriteLine("Good luck on your Eternal Quest!");
    }
}
