using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    // Constructor for new checklist goal
    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = Math.Max(1, target);
        _bonus = bonus;
        _amountCompleted = 0;
    }

    // Constructor used when loading (amountCompleted provided)
    public ChecklistGoal(string name, string description, int points, int target, int amountCompleted, int bonus)
        : base(name, description, points)
    {
        _target = Math.Max(1, target);
        _amountCompleted = Math.Max(0, amountCompleted);
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (IsComplete()) return 0;
        _amountCompleted++;
        if (_amountCompleted >= _target)
        {
            // On completion: award points for this event plus bonus
            return Points + _bonus;
        }
        return Points;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        return $"[ {(IsComplete() ? "X" : " ")} ] {ShortName} ({Description}) - {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist:{ShortName}|{Description}|{Points}|{_target}|{_amountCompleted}|{_bonus}";
    }
}
