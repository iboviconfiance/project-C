using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        // never completes; each event gives points
        return Points;
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"[ ∞ ] {ShortName} ({Description}) - +{Points} each time";
    }

    public override string GetStringRepresentation()
    {
        return $"Eternal:{ShortName}|{Description}|{Points}";
    }
}
