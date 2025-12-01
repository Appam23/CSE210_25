namespace MindfulActivities
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                // Display menu
                Console.Clear();
              
                Console.WriteLine("MINDFULNESS ACTIVITIES MENU");
                ;
                Console.WriteLine();
                Console.WriteLine("Choose an activity:");
                Console.WriteLine();
                Console.WriteLine("  1. Listing Activity");
                Console.WriteLine("  2. Breathing Activity");
                Console.WriteLine("  3. Reflection Activity");
                Console.WriteLine("  4. Nature Healing Activity");
                Console.WriteLine("  5. Exit");
                Console.WriteLine();
                Console.Write("Enter your choice (1-5): ");

                string choice = Console.ReadLine() ?? "";

                Console.WriteLine();

                // Process choice
                if (choice == "1")
                {
                    Console.Write("How many seconds for this activity? ");
                    int duration = GetPositiveInteger();
                    Listing listing = new Listing();
                    listing.SetDurationSeconds(duration);
                    listing.Start();
                }
                else if (choice == "2")
                {
                    Console.Write("How many seconds for this activity? ");
                    int duration = GetPositiveInteger();
                    Breathing breathing = new Breathing();
                    breathing.SetDurationSeconds(duration);
                    breathing.Start();
                }
                else if (choice == "3")
                {
                    Console.Write("How many seconds for this activity? ");
                    int duration = GetPositiveInteger();
                    Reflection reflection = new Reflection();
                    reflection.SetDurationSeconds(duration);
                    reflection.Start();
                }
                else if (choice == "4")
                {
                    Console.Write("How many seconds for this activity? ");
                    int duration = GetPositiveInteger();
                    NatureHealing nature = new NatureHealing();
                    nature.SetDurationSeconds(duration);
                    nature.Start();
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Thank you for practicing mindfulness. Goodbye! 🌟");
                    running = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 1, 2, 3, 4, or 5.");
                }

                // Wait before showing menu again
                if (running)
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                }
            }
        }

        static int GetPositiveInteger()
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value > 0)
                {
                    return value;
                }
                Console.Write("Please enter a positive number: ");
            }
        }
    }
}
