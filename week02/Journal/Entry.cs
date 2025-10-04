using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string promptText, string entryText)
    {
        _date = DateTime.Now.ToShortDateString();
        _promptText = promptText;
        _entryText = entryText;
    }

    public string GetEntryAsCsv()
    {
        return $"{_date}|~|{_promptText}|~|{_entryText}";
    }

    public static Entry FromCsv(string line)
    {
        string[] parts = line.Split("|~|");
        if (parts.Length == 3)
        {
            Entry e = new Entry(parts[1], parts[2]);
            e._date = parts[0]; // reuse stored date
            return e;
        }
        return null;
    }

    public string GetDate()
    {
        return _date;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine("-----------------------------------");
    }
}
