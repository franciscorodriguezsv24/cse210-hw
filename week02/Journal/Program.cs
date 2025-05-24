using System;

class Program
{
    private static Journal _journal = new Journal();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your Personal Journal!");
        
        while (true)
        {
            ShowMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    Console.WriteLine("Thank you for using your Personal Journal! Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please select an option from 1 to 5.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\n=== PERSONAL JOURNAL MENU ===");
        Console.WriteLine("Please select one of the following options:");
        Console.WriteLine("1. Write new entry");
        Console.WriteLine("2. Display journal");
        Console.WriteLine("3. Save journal to file");
        Console.WriteLine("4. Load journal from file");
        Console.WriteLine("5. Exit");
        Console.Write("What would you like to do? ");
    }

    static void WriteNewEntry()
    {
        Console.WriteLine("\n=== NEW ENTRY ===");
        
        string prompt = _journal.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        
        string response = Console.ReadLine();
        
        if (!string.IsNullOrWhiteSpace(response))
        {
            _journal.AddEntry(prompt, response);
            Console.WriteLine("Entry saved successfully!");
        }
        else
        {
            Console.WriteLine("Cannot save an empty response.");
        }
    }

    static void DisplayJournal()
    {
        _journal.DisplayJournal();
    }

    static void SaveJournal()
    {
        Console.WriteLine("\n=== SAVE JOURNAL ===");
        Console.Write("Enter the file name (e.g., my_journal.txt): ");
        string filename = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(filename))
        {
            _journal.SaveToFile(filename);
        }
        else
        {
            Console.WriteLine("Invalid file name.");
        }
    }

    static void LoadJournal()
    {
        Console.WriteLine("\n=== LOAD JOURNAL ===");
        Console.Write("Enter the file name to load: ");
        string filename = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("WARNING: This will replace all current journal entries.");
            Console.Write("Are you sure? (y/n): ");
            string confirmation = Console.ReadLine().ToLower();

            if (confirmation == "y" || confirmation == "yes")
            {
                _journal.LoadFromFile(filename);
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }
        else
        {
            Console.WriteLine("Invalid file name.");
        }
    }
}