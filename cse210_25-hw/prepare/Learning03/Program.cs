using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter the scripture reference (e.g., John 3:16): ");
        string referenceInput = Console.ReadLine();
        Console.Write("Enter the scripture text: ");
        string textInput = Console.ReadLine();

        Reference reference = new Reference(referenceInput);
        Scripture scripture = new Scripture(reference, textInput);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.ToString());

            if (scripture.AllHidden())
            {
                Console.WriteLine("All words are hidden. Well done!");
                break;
            }

            Console.Write("Press Enter to hide more words or type 'quit' to exit: ");
            string input = Console.ReadLine();
            if (input.Trim().ToLower() == "quit")
                break;
            scripture.HideRandomWords();
        }
    }
}