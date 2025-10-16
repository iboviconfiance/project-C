using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // Creativity: leveling & badges
    private int _level = 1;
    private HashSet<string> _badges = new HashSet<string>();

    // Read-only accessors
    public IReadOnlyList<Goal> Goals => _goals.AsReadOnly();
    public int Score => _score;
    public int Level => _level;

    // Add goal to manager
    public void AddGoal(Goal goal)
    {
        if (goal != null) _goals.Add(goal);
    }

    // Start: interactive menu loop (diagram expected Start())
    public void Start()
    {
        bool quit = false;
        while (!quit)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goal Names");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Show Goal Details");
            Console.WriteLine("7. Exit");
            Console.Write("Choice: ");
            var choice = Console.ReadLine()?.Trim();
            Console.WriteLine();
            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalNames(); break;
                case "3": HandleRecordEvent(); break;
                case "4": Console.Write("Filename to save to (default: goals.txt): "); var f = Console.ReadLine(); SaveGoals(string.IsNullOrWhiteSpace(f) ? "goals.txt" : f.Trim()); break;
                case "5": Console.Write("Filename to load from (default: goals.txt): "); var lf = Console.ReadLine(); LoadGoals(string.IsNullOrWhiteSpace(lf) ? "goals.txt" : lf.Trim()); break;
                case "6": ListGoalDetails(); break;
                case "7": quit = true; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Score: {_score}   Level: {_level}   Badges: {(_badges.Count == 0 ? "(none)" : string.Join(", ", _badges))}");
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0) { Console.WriteLine("No goals created."); return; }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0) { Console.WriteLine("No goals created."); return; }
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    // CreateGoal method requested by diagram
    public void CreateGoal()
    {
        Console.WriteLine("Choose type: 1=Simple, 2=Eternal, 3=Checklist");
        Console.Write("Type: ");
        var t = Console.ReadLine()?.Trim();
        Console.Write("Short name: "); var name = Console.ReadLine() ?? "Unnamed";
        Console.Write("Description: "); var desc = Console.ReadLine() ?? "";
        Console.Write("Points per event: "); var pstr = Console.ReadLine(); int points = int.TryParse(pstr, out var ptmp) ? ptmp : 0;

        switch (t)
        {
            case "1":
                AddGoal(new SimpleGoal(name, desc, points));
                Console.WriteLine("Simple goal created.");
                break;
            case "2":
                AddGoal(new EternalGoal(name, desc, points));
                Console.WriteLine("Eternal goal created.");
                break;
            case "3":
                Console.Write("Target count: "); var tgtS = Console.ReadLine(); int target = int.TryParse(tgtS, out var ttmp) ? Math.Max(1, ttmp) : 1;
                Console.Write("Bonus on completion: "); var bS = Console.ReadLine(); int bonus = int.TryParse(bS, out var btmp) ? btmp : 0;
                AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                Console.WriteLine("Checklist goal created.");
                break;
            default:
                Console.WriteLine("Unknown type.");
                break;
        }
    }

    // Wrapper that asks for the index and records event
    public void HandleRecordEvent()
    {
        if (_goals.Count == 0) { Console.WriteLine("No goals yet."); return; }
        ListGoalDetails();
        Console.Write("Which goal number did you complete/record? ");
        var s = Console.ReadLine();
        if (int.TryParse(s, out var idx))
        {
            RecordEvent(idx - 1);
        }
        else
        {
            Console.WriteLine("Bad input.");
        }
    }

    // RecordEvent(index) requested by diagram
    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count) { Console.WriteLine("Index out of range."); return; }
        var goal = _goals[index];
        int earned = goal.RecordEvent();
        if (earned > 0)
        {
            _score += earned;
            Console.WriteLine($"You earned {earned} points!");
            CheckLevelUp();
            CheckBadges(goal);
        }
        else
        {
            Console.WriteLine("No points earned (maybe already completed).");
        }
    }

    private void CheckLevelUp()
    {
        int newLevel = (_score / 1000) + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"*** Level up! You are now level {_level}! ***");
        }
    }

    private void CheckBadges(Goal g)
    {
        string badge = $"Tried: {g.ShortName}";
        if (!_badges.Contains(badge))
        {
            _badges.Add(badge);
            Console.WriteLine($"Badge earned: {badge}");
        }

        if (g is EternalGoal)
        {
            if (_score >= 500 && !_badges.Contains("Habit Builder"))
            {
                _badges.Add("Habit Builder");
                Console.WriteLine("Badge earned: Habit Builder (500+ points)!");
            }
        }
    }

    // SaveGoals(filename) and LoadGoals(filename)
    public void SaveGoals(string filename)
    {
        using (var sw = new StreamWriter(filename))
        {
            // Header lines: score, level, badges (comma separated)
            sw.WriteLine(_score);
            sw.WriteLine(_level);
            sw.WriteLine(string.Join(',', _badges));
            // Then one line per goal using GetStringRepresentation()
            foreach (var g in _goals)
            {
                sw.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Saved to {filename}");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename)) { Console.WriteLine("Save file not found."); return; }
        var lines = File.ReadAllLines(filename);
        if (lines.Length < 1) return;
        int i = 0;
        _score = int.TryParse(lines[i++], out var sParsed) ? sParsed : 0;
        _level = (i < lines.Length && int.TryParse(lines[i++], out var lvl)) ? lvl : 1;
        _badges.Clear();
        if (i < lines.Length)
        {
            var badgesLine = lines[i++];
            if (!string.IsNullOrWhiteSpace(badgesLine))
            {
                foreach (var b in badgesLine.Split(',')) if (!string.IsNullOrWhiteSpace(b)) _badges.Add(b);
            }
        }
        _goals.Clear();
        for (; i < lines.Length; i++)
        {
            try
            {
                var g = Goal.CreateFromString(lines[i]);
                _goals.Add(g);
            }
            catch
            {
                // skip malformed lines but inform user
                Console.WriteLine($"Warning: Could not parse goal line: {lines[i]}");
            }
        }
        Console.WriteLine($"Loaded from {filename}");
    }
}
