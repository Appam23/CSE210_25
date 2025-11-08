namespace MindfulActivities
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    // Reflection activity: reflect on times of strength and resilience
    public class Reflection : Activity
    {
        private readonly List<string> _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private readonly List<string> _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private readonly Random _rng = new Random();
        private readonly string[] _spinnerChars = { "|", "/", "-", "\\" };

        public Reflection() : base(
            startMessage: "Get ready to reflect on times of strength and resilience.",
            endMessage: "Reflection complete. You have shown great strength!")
        {
        }

        // Main activity logic
        protected override void Run()
        {
            Console.WriteLine();
            Console.WriteLine("This activity will help you reflect on times in your life when you have shown strength and resilience.");
            Console.WriteLine("This will help you recognize the power you have and how you can use it in other aspects of your life.");
            Console.WriteLine();
            Console.WriteLine($"Duration: {ActivityDuration().TotalSeconds:F0} seconds");
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            Countdown(3);
            Console.WriteLine();

            // Select and display a random prompt
            int promptIndex = _rng.Next(_prompts.Count);
            Console.WriteLine(_prompts[promptIndex]);
            Console.WriteLine();

            // Track which questions have been asked to avoid immediate repeats
            List<int> usedQuestions = new List<int>();

            // Keep showing questions until time runs out
            while (TimeRemaining())
            {
                // Get a random question
                int questionIndex;
                if (usedQuestions.Count >= _questions.Count)
                {
                    // Reset if we've used all questions
                    usedQuestions.Clear();
                }
                
                do
                {
                    questionIndex = _rng.Next(_questions.Count);
                } while (usedQuestions.Contains(questionIndex));
                
                usedQuestions.Add(questionIndex);

                // Display the question
                Console.WriteLine($"> {_questions[questionIndex]}");

                // Pause with spinner for several seconds (5 seconds)
                ShowSpinner(5);

                if (!TimeRemaining())
                {
                    break;
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        // Display a spinner animation for the specified number of seconds
        private void ShowSpinner(int seconds)
        {
            DateTime endTime = DateTime.UtcNow.AddSeconds(seconds);

            while (DateTime.UtcNow < endTime && TimeRemaining())
            {
                foreach (string spinChar in _spinnerChars)
                {
                    Console.Write($"\r{spinChar} ");
                    Thread.Sleep(250); // Update spinner every 250ms
                    
                    if (DateTime.UtcNow >= endTime || !TimeRemaining())
                    {
                        break;
                    }
                }
            }

            // Clear the spinner line
            Console.Write("\r  \r");
        }
    }
}