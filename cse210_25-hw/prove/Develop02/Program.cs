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
            // Determine format based on file extension
            bool isCsv = filename.ToLower().EndsWith(".csv");
            
            using (StreamWriter writer = new StreamWriter(filename))
            {
                if (isCsv)
                {
                    // Write CSV header
                    writer.WriteLine("Date,Prompt,Response");
                    
                    // Write entries in CSV format
                    foreach (JournalEntry entry in _entries)
                    {
                        string csvLine = $"{EscapeCsvField(entry.Date)},{EscapeCsvField(entry.Prompt)},{EscapeCsvField(entry.Response)}";
                        writer.WriteLine(csvLine);
                    }
                }
                else
                {
                    // Write in original text format
                    foreach (JournalEntry entry in _entries)
                    {
                        writer.WriteLine(entry.ToString());
                        writer.WriteLine("-------------------");
                    }
                }
            }
            
            string format = isCsv ? "CSV" : "text";
            Console.WriteLine($"\n✅ Successfully saved {_entries.Count} entries to '{filename}' in {format} format!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error saving file: {ex.Message}");
        }
    }

    private string EscapeCsvField(string field)
    {
        if (string.IsNullOrEmpty(field))
            return "\"\"";
            
        // Check if field contains comma, quote, or newline
        bool needsQuoting = field.Contains(",") || field.Contains("\"") || field.Contains("\n") || field.Contains("\r");
        
        if (needsQuoting)
        {
            // Escape quotes by doubling them
            string escapedField = field.Replace("\"", "\"\"");
            return $"\"{escapedField}\"";
        }
        
        return field;
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
            
            // Determine format based on file extension
            bool isCsv = filename.ToLower().EndsWith(".csv");
            
            if (isCsv)
            {
                // Parse CSV format
                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();
                    
                    // Skip empty lines
                    if (string.IsNullOrEmpty(line))
                        continue;
                        
                    // Skip header line (first non-empty line)
                    if (i == 0 && (line.StartsWith("Date,") || line.StartsWith("\"Date\"")))
                        continue;
                    
                    // Parse CSV line
                    string[] fields = ParseCsvLine(line);
                    if (fields.Length >= 3)
                    {
                        loadedEntries.Add(new JournalEntry(fields[0], fields[1], fields[2]));
                    }
                }
            }
            else
            {
                // Parse text formats (original logic)
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
            }
            
            if (loadedEntries.Count == 0)
            {
                Console.WriteLine($"❌ No valid journal entries found in '{filename}'.");
                return;
            }
            
            // Replace current entries with loaded entries
            _entries = loadedEntries;
            string format = isCsv ? "CSV" : "text";
            Console.WriteLine($"✅ Successfully loaded {_entries.Count} entries from '{filename}' in {format} format!");
            Console.WriteLine("🔄 Previous entries have been replaced with loaded entries.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Error loading file: {ex.Message}");
        }
    }

    private string[] ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        bool inQuotes = false;
        string currentField = "";
        
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            
            if (c == '"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                {
                    // Double quote - add single quote to field
                    currentField += '"';
                    i++; // Skip next quote
                }
                else
                {
                    // Toggle quote mode
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                // End of field
                fields.Add(currentField);
                currentField = "";
            }
            else
            {
                currentField += c;
            }
        }
        
        // Add the last field
        fields.Add(currentField);
        
        return fields.ToArray();
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
        
        Console.Write("Enter the filename to load from (e.g., 'my_journal.txt' or 'my_journal.csv'): ");
        string filename = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("❌ Invalid filename. Load cancelled.");
            return;
        }
        
        if (!filename.Contains("."))
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
        
        Console.WriteLine("Choose format:");
        Console.WriteLine("1. CSV format (.csv) - Opens in Excel/Google Sheets");
        Console.WriteLine("2. Text format (.txt) - Human readable");
        Console.Write("Select format (1 or 2): ");
        string formatChoice = Console.ReadLine();
        
        string defaultExtension = (formatChoice == "1") ? ".csv" : ".txt";
        string exampleName = (formatChoice == "1") ? "my_journal.csv" : "my_journal.txt";
        
        Console.Write($"Enter the filename to save to (e.g., '{exampleName}'): ");
        string filename = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("❌ Invalid filename. Save cancelled.");
            return;
        }
        
        if (!filename.Contains("."))
        {
            filename += defaultExtension;
        }
        
        _journal.SaveToFile(filename);
        Console.WriteLine($"📍 File location: {Path.GetFullPath(filename)}");
        
        if (filename.ToLower().EndsWith(".csv"))
        {
            Console.WriteLine("💡 You can now open this CSV file in Excel, Google Sheets, or any spreadsheet program!");
        }
    }
}