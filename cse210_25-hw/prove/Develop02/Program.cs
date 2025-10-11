using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n Appam's Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save entries to file");
            Console.WriteLine("4. Load entries from file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose the options above: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Entry newEntry = new Entry();
                string date = newEntry.GetDate();
                string prompt = newEntry.GetPrompt();
                string response = newEntry.GetResponse();
                Entry completedEntry = new Entry(date, prompt, response);
                myJournal.AddEntry(completedEntry);
                Console.WriteLine("Entry added!");
            }
            else if (choice == "2")
            {
                myJournal.DisplayEntries();
            }
            else if (choice == "3")
            {
                myJournal.SaveToFile("appam's_journal.txt");
            }
            else if (choice == "4")
            {
                myJournal.LoadFromFile("appam's_journal.txt");
            }
            else if (choice == "5")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }

        Console.WriteLine("Goodbye!");
    }
}