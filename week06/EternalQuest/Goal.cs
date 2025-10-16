using System;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    protected Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Read-only properties (encapsulation)
    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;

    // Polymorphic behavior
    public abstract int RecordEvent(); // returns points earned for this record
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation(); // for saving

    // Factory to create a Goal from saved string
    public static Goal CreateFromString(string data)
    {
        // Format expected:
        // Simple:name|description|points|completed(0/1)
        // Eternal:name|description|points
        // Checklist:name|description|points|target|amountCompleted|bonus

        if (string.IsNullOrWhiteSpace(data)) throw new ArgumentException("Empty data");
        var parts = data.Split(':', 2);
        if (parts.Length < 2) throw new ArgumentException("Bad format");
        var type = parts[0];
        var payload = parts[1];
        var fields = payload.Split('|');

        switch (type)
        {
            case "Simple":
                return new SimpleGoal(fields[0], fields[1], int.Parse(fields[2]), fields.Length > 3 && fields[3] == "1");
            case "Eternal":
                return new EternalGoal(fields[0], fields[1], int.Parse(fields[2]));
            case "Checklist":
                // fields: name|description|points|target|amountCompleted|bonus
                return new ChecklistGoal(fields[0], fields[1], int.Parse(fields[2]), int.Parse(fields[3]), int.Parse(fields[4]), int.Parse(fields[5]));
            default:
                throw new ArgumentException($"Unknown goal type {type}");
        }
    }
}
