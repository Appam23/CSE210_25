using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulActivities
{
    // NatureHealing activity: guide a nature awareness exercise
    public class NatureHealing : Activity
    {
        private readonly List<string> _prompts = new List<string>()
        {
            "Close your eyes and imagine a calm lake. Hear the water lap gently.",
            "Picture a meadow with a soft breeze and wildflowers.",
            "Imagine a quiet pine forest. Notice the smell and soft crunch underfoot.",
            "Visualize waves on a sandy beach. Listen to the surf and feel the salt air."
        };

        private readonly Random _rng = new Random();

        public NatureHealing() : base(
            startMessage: "Connect with nature. Find a comfortable position.",
            endMessage: "Nature awareness session complete.")
        {
        }

        // Concrete behaviour: present ambience, allow a short guided sensory pause, then prompt for reflection(s)
        protected override void Run()
        {
            Console.WriteLine();
            Console.WriteLine($"You have {ActivityDuration().TotalSeconds:F0} seconds for this session.");
            Console.WriteLine();

            // Show a random nature prompt
            int index = _rng.Next(_prompts.Count);
            Console.WriteLine(_prompts[index]);
            Console.WriteLine();
            Console.WriteLine("Close your eyes and imagine this scene...");
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            base.Countdown(3);  // Use parent's Countdown method that prints: 3... 2... 1...
            Console.WriteLine();

            // Wait for the duration while showing timer
            while (TimeRemaining())
            {
                // Delay 10ms - updates animation every 100ms (every 10 checks)
                Thread.Sleep(100);
            }

            Console.WriteLine();
            Console.WriteLine("Open your eyes when you're ready.");
        }
    }
}