using System;

class Program
{
    static void Main(string[] args)
    {
        // Create multiple scripture options
        Console.WriteLine("Choose a scripture to memorize:");
        Console.WriteLine("1. Matthew 6:33");
        Console.WriteLine("2. Proverbs 3:5-6");
        Console.Write("Enter your choice (1 or 2): ");
        
        string choice = Console.ReadLine();
        
        Refrence reference;
        string scriptureText;
        
        if (choice == "1")
        {
            // Matthew 6:33
            reference = new Refrence("Matthew", 6, 33);
            scriptureText = "But seek first his kingdom and his righteousness and all these things will be given to you as well";
        }
        else
        {
            // Proverbs 3:5-6 (default)
            reference = new Refrence("Proverbs", 3, 5, 6);
            scriptureText = "Trust in the Lord with all your heart and lean not on your own understanding in all your ways submit to him and he will make your paths straight";
        }
        
        Scripture scripture = new Scripture(reference, scriptureText);
        
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