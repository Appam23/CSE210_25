namespace MindfulActivities
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    // Listing activity: list as many things as you can in a certain area
    public class Listing : Activity
    {
        private readonly List<string> _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private readonly List<string> _items = new List<string>();
        private readonly Random _rng = new Random();

        public Listing() : base(
            startMessage: "Get ready to list items.",
            endMessage: "Well done!")
        {
        }

        // Concrete activity behaviour: show prompt, accept inputs until time expires
        protected override void Run()
        {
            Console.WriteLine();
            Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
            Console.WriteLine();
            Console.WriteLine($"Duration: {ActivityDuration().TotalSeconds:F0} seconds");
            Console.WriteLine();

            // Select and display a random prompt
            int promptIndex = _rng.Next(_prompts.Count);
            Console.WriteLine("List Prompt:");
            Console.WriteLine($"--- {_prompts[promptIndex]} ---");
            Console.WriteLine();

            // Countdown to begin thinking
            Console.WriteLine("You may begin in...");
            Countdown(5);
            Console.WriteLine();
            Console.WriteLine("Start listing!");

            // Read lines until time runs out
            while (TimeRemaining())
            {
                // Non-blocking read approach: check if input is available
                if (Console.KeyAvailable)
                {
                    string line = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        _items.Add(line.Trim());
                    }
                }
                else
                {
                    // Small sleep to avoid busy-waiting
                    Thread.Sleep(100);
                }
            }

            // Time expired; show count of items entered
            Console.WriteLine();
            Console.WriteLine($"You listed {_items.Count} items!");
        }
    }
}