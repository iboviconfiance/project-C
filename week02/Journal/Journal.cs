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
            Console.WriteLine("The journal is empty.");
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
        Console.WriteLine($"Journal saved to {file}");
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
            Console.WriteLine($"Journal loaded from {file}");
        }
        else
        {
            Console.WriteLine("⚠️ File not found.");
        }
    }

    // ✨ Creative feature: delete an entry by index
    public void DeleteEntry(int index)
    {
        if (index >= 0 && index < _entries.Count)
        {
            _entries.RemoveAt(index);
            Console.WriteLine("Entry deleted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }

    // ✨ Creative feature: search by date
    public void SearchByDate(string date)
    {
        bool found = false;
        foreach (Entry entry in _entries)
        {
            if (entry.GetDate() == date)
            {
                entry.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No entries found for this date.");
        }
    }

    // Helper: show entries with index
    public void DisplayAllWithIndex()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"{i}. {_entries[i].GetDate()} - entry preview");
        }
    }
}
