using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The log is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetEntryAsCsv());
            }
        }
        Console.WriteLine($"Log is store in {file}");
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                Entry entry = Entry.FromCsv(line);
                if (entry != null)
                {
                    _entries.Add(entry);
                }
            }
            Console.WriteLine($"Log loaded from {file}");
        }
        else
        {
            Console.WriteLine("⚠️ File not found.");
        }
    }
}
