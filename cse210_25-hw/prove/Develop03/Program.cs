using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        // Find scripture.txt in the same directory as the executable, regardless of working directory
        string exeDir = AppDomain.CurrentDomain.BaseDirectory;
        string scripturePath = Path.Combine(exeDir, "scripture.txt");
        if (!File.Exists(scripturePath))
        {
            // Try relative to project folder if not found
            scripturePath = Path.Combine(exeDir, "prove/Develop03/scripture.txt");
        }
        if (!File.Exists(scripturePath))
        {
            Console.WriteLine($"Could not find scripture.txt. Looked in: {exeDir} and {exeDir}prove/Develop03/");
            Console.WriteLine("Please make sure scripture.txt is in the correct location.");
            return;
        }
        string[] allLines = File.ReadAllLines(scripturePath);
        List<(string reference, string text)> scriptures = new List<(string, string)>();
        string currentReference = null;
        string currentText = null;
        foreach (string line in allLines)
        {
            if (string.IsNullOrWhiteSpace(line) || line.Trim() == "---")
            {
                if (!string.IsNullOrEmpty(currentReference) && !string.IsNullOrEmpty(currentText))
                {
                    scriptures.Add((currentReference, currentText));
                }
                currentReference = null;
                currentText = null;
                continue;
            }
            if (currentReference == null)
            {
                currentReference = line.Trim();
            }
            else if (currentText == null)
            {
                currentText = line.Trim();
            }
        }
        // Add the last scripture if file doesn't end with ---
        if (!string.IsNullOrEmpty(currentReference) && !string.IsNullOrEmpty(currentText))
        {
            scriptures.Add((currentReference, currentText));
        }

        // Show menu to user
        Console.WriteLine("Choose a scripture to memorize:");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].reference}");
        }
        Console.Write("Enter your choice (1 - {0}): ", scriptures.Count);
        int selection = 1;
        string input = Console.ReadLine();
        if (!int.TryParse(input, out selection) || selection < 1 || selection > scriptures.Count)
        {
            selection = 1;
        }
        var chosen = scriptures[selection - 1];

        // Parse reference (support multi-word book names)
        string[] parts = chosen.reference.Split(' ');
        string chapterVersePart = parts[parts.Length - 1];
        string book = string.Join(" ", parts, 0, parts.Length - 1);
        string[] chapterAndVerses = chapterVersePart.Split(':');
        int chapter = int.Parse(chapterAndVerses[0]);
        string[] verses = chapterAndVerses[1].Split('-');
        int startVerse = int.Parse(verses[0]);
        int endVerse = verses.Length > 1 ? int.Parse(verses[1]) : startVerse;

    Reference reference = new Reference(book, chapter, startVerse, endVerse);
    Scripture scripture = new Scripture(reference, chosen.text);

        // Display welcome message
        Console.WriteLine("Welcome to Scripture Memorizer!");
        Console.WriteLine("Press Enter to hide words, or type 'quit' to exit.\n");

        // Main game loop
        while (true)
        {
            // Clear the console for a clean display
            Console.Clear();

            // Display the current state of the scripture
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // Check if all words are hidden (game complete)
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Congratulations! You have memorized the entire scripture!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                break;
            }

            // Prompt user for input
            Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit:");
            string userInput = Console.ReadLine();

            // Check if user wants to quit
            if (userInput.ToLower() == "quit")
            {
                Console.WriteLine("Thanks for practicing! Keep studying!");
                break;
            }

            // Hide 1-3 random words each turn
            Random random = new Random();
            int wordsToHide = random.Next(1, 4); // Hide 1, 2, or 3 words
            scripture.HideRandomWords(wordsToHide);
        }
    }
}