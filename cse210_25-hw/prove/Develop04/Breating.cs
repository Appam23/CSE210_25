using System;
using System.Threading;

namespace MindfulActivities
{
    // Breathing activity: guides user through breathing in and out slowly
    public class Breathing : Activity
    {
        public Breathing()
            : base(startMessage: "Get ready to relax.",
                    endMessage: "Well done! You have completed the breathing exercise.")
        {
        }

        // Concrete activity behaviour: alternate between breathe in and breathe out
        protected override void Run()
        {
            Console.WriteLine();
            Console.WriteLine("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
            Console.WriteLine();
            Console.WriteLine($"Duration: {ActivityDuration().TotalSeconds:F0} seconds");
            Console.WriteLine();
            Console.Write("Get ready...");
            ShowSpinner(3);
            Console.WriteLine();

            bool breatheIn = true;

            // Continue alternating breathe in/out until time runs out
            while (TimeRemaining())
            {
                if (breatheIn)
                {
                    Console.Write("Breathe in...");
                }
                else
                {
                    Console.Write("Breathe out...");
                }

                // Countdown for several seconds (4 seconds)
                PrintCountdown(4);

                if (!TimeRemaining()) break;

                Console.WriteLine();

                // Toggle between breathe in and breathe out
                breatheIn = !breatheIn;
            }

            Console.WriteLine();
        }

        // Display countdown after the breathing message
        private void PrintCountdown(int seconds)
        {
            Console.Write(" ");
            for (int i = seconds; i >= 1; i--)
            {
                if (!TimeRemaining())
                {
                    Console.WriteLine();
                    return;
                }
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b"); // Backspace to erase the number
            }
            Console.WriteLine();
        }
    }
}