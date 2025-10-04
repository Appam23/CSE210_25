using System;
using System.Collections.Generic;
using System.IO;

class JournalEntry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public JournalEntry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

class Journal
{
    private List<JournalEntry> _entries;
    private List<string> _prompts;
    private Random _random;

    public Journal()
    {
        _entries = new List<JournalEntry>();
        _random = new Random();
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What made me smile today?",
            "What challenged me the most today?",
            "What am I grateful for today?"
        };
    }

    public void AddEntry()
    {
        // Select a random prompt
        string selectedPrompt = _prompts[_random.Next(_prompts.Count)];
        
        // Display the prompt and get user response
        Console.WriteLine($"\nToday's journal prompt:");
        Console.WriteLine($"{selectedPrompt}");
        Console.Write("\nYour response: ");
        string response = Console.ReadLine();

        // Create the journal entry
        string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        JournalEntry entry = new JournalEntry(date, selectedPrompt, response);

        // Add to entries list
        _entries.Add(entry);

        Console.WriteLine("\n✅ Your journal entry has been added!");
    }

    public void DisplayAllEntries()
    {
        Console.WriteLine("\n📖 Your Journal Entries:");
        Console.WriteLine("========================");
        
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found. Start by writing your first entry!");
            return;
        }
        
        // Display all entries
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"Entry #{i + 1}:");
            Console.WriteLine(_entries[i].ToString());
            Console.WriteLine("-------------------");
        }
        
        Console.WriteLine($"Total entries: {_entries.Count}");
    }

    public void SaveToFile(string filename)
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries to save.");
            return;
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (JournalEntry entry in _entries)
                {
                    writer.WriteLine(entry.ToString());
                    writer.WriteLine("-------------------");
                }
            }
            
            Console.WriteLine($"\n✅ Successfully saved {_entries.Count} entries to '{filename}'!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"❌ File '{filename}' not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            List<JournalEntry> loadedEntries = new List<JournalEntry>();
            
            // Parse the file to extract journal entries
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                
                // Check if this line starts with "Date:" (new format)
                if (line.StartsWith("Date: "))
                {
                    if (i + 2 < lines.Length && 
                        lines[i + 1].StartsWith("Prompt: ") && 
                        lines[i + 2].StartsWith("Response: "))
                    {
                        string date = line.Substring(6); // Remove "Date: "
                        string prompt = lines[i + 1].Substring(8); // Remove "Prompt: "
                        string response = lines[i + 2].Substring(10); // Remove "Response: "
                        
                        loadedEntries.Add(new JournalEntry(date, prompt, response));
                        i += 2; // Skip the next two lines since we've processed them
                    }
                }
                // Handle old format (date|prompt|response)
                else if (line.Contains("|"))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        loadedEntries.Add(new JournalEntry(parts[0], parts[1], parts[2]));
                    }
                }
            }
            
            if (loadedEntries.Count == 0)
            {
                Console.WriteLine($"❌ No valid journal entries found in '{filename}'.");
                return;
            }
            
            // Replace current entries with loaded entries
            _entries = loadedEntries;
            Console.WriteLine($"✅ Successfully loaded {_entries.Count} entries from '{filename}'!");
            Console.WriteLine("🔄 Previous entries have been replaced with loaded entries.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error loading file: {ex.Message}");
        }
    }

    public int GetEntryCount()
    {
        return _entries.Count;
    }
}

class Program
{
    private static Journal _journal;

    static void Main()
    {
        _journal = new Journal();
        
        Console.WriteLine("Welcome to the Journal Program!");
        
        while (true)
        {
            DisplayMenu();
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    _journal.AddEntry();
                    break;
                case "2":
                    _journal.DisplayAllEntries();
                    break;
                case "3":
                    LoadJournal();
                    break;
                case "4":
                    SaveJournal();
                    break;
                case "5":
                    Console.WriteLine("Thank you for using the Journal Program!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, 3, 4, or 5.");
                    break;
            }
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("\nPlease select one of the following choices:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Load journal from file");
        Console.WriteLine("4. Save journal to file");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
    }

    private static void LoadJournal()
    {
        Console.WriteLine("\n📂 Load Journal from File");
        Console.WriteLine("==========================");
        
        Console.Write("Enter the filename to load from (e.g., 'my_journal.txt'): ");
        string filename = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("❌ Invalid filename. Load cancelled.");
            return;
        }
        
        if (!filename.EndsWith(".txt"))
        {
            filename += ".txt";
        }
        
        _journal.LoadFromFile(filename);
    }

    private static void SaveJournal()
    {
        Console.WriteLine("\n💾 Save Journal to File");
        Console.WriteLine("========================");
        
        if (_journal.GetEntryCount() == 0)
        {
            Console.WriteLine("No journal entries to save. Write some entries first!");
            return;
        }
        
        Console.Write("Enter the filename to save to (e.g., 'my_journal.txt'): ");
        string filename = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("❌ Invalid filename. Save cancelled.");
            return;
        }
        
        if (!filename.EndsWith(".txt"))
        {
            filename += ".txt";
        }
        
        _journal.SaveToFile(filename);
        Console.WriteLine($"📍 File location: {Path.GetFullPath(filename)}");
    }
}