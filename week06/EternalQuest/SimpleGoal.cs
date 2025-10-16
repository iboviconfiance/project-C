using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points, bool completed = false)
        : base(name, description, points)
    {
        _isComplete = completed;
    }

    public override int RecordEvent()
    {
        if (_isComplete) return 0;
        _isComplete = true;
        return Points;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDetailsString()
    {
        return $"[ {(_isComplete ? "X" : " ")} ] {ShortName} ({Description}) - {(_isComplete ? "Completed" : "Not completed")}";
    }

    public override string GetStringRepresentation()
    {
        return $"Simple:{ShortName}|{Description}|{Points}|{(_isComplete ? "1" : "0")}";
    }
}
