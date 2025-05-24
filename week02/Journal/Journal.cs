using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<Entry> _entries;
    private List<string> _prompts;
    private Random _random;

    public Journal()
    {
        _entries = new List<Entry>();
        _random = new Random();
        InitializePrompts();
    }

    private void InitializePrompts()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I could do something differently today, what would it be?",
            "What did I learn today that I didn't know yesterday?",
            "What am I most grateful for today?",
            "What was the most challenging moment of my day and how did I handle it?"
        };
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void AddEntry(string prompt, string response)
    {
        Entry entry = new Entry(prompt, response);
        _entries.Add(entry);
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no entries in the journal.");
            return;
        }

        Console.WriteLine("\n=== JOURNAL ENTRIES ===");
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"\nEntry #{i + 1}:");
            Console.WriteLine(_entries[i].ToString());
            Console.WriteLine(new string('-', 50));
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.ToFileFormat());
                }
            }
            Console.WriteLine($"Journal successfully saved to '{filename}'");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"The file '{filename}' does not exist.");
                return;
            }

            _entries.Clear();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    Entry entry = Entry.FromFileFormat(line);
                    if (entry != null)
                    {
                        _entries.Add(entry);
                    }
                }
            }

            Console.WriteLine($"Journal successfully loaded from '{filename}'. {_entries.Count} entries loaded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    public int GetEntryCount()
    {
        return _entries.Count;
    }
}
