using System;
using System.Collections.Generic;
using System.IO;
using GoalTracker.Models;

namespace GoalTracker
{
    class Program
    {
        private static List<Goal> _goals = new List<Goal>();
        private static int _score = 0;
        private const string SaveFile = "goal.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Goal Tracker (All Goal Types)\n");
            
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine("1) Create a Simple goal");
                Console.WriteLine("2) Create an Eternal goal");
                Console.WriteLine("3) Create a Checklist goal");
                Console.WriteLine("4) Create a Negative goal");
                Console.WriteLine("5) List goals");
                Console.WriteLine("6) Record an event");
                Console.WriteLine("7) Show score");
                Console.WriteLine("8) Save goals");
                Console.WriteLine("9) Load goals");
                Console.WriteLine("10) Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine()?.Trim();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            CreateSimpleGoal();
                            break;
                        case "2":
                            CreateEternalGoal();
                            break;
                        case "3":
                        CreateChecklistGoal();
                        break;
                    case "4":
                        CreateNegativeGoal();
                        break;
                    case "5":
                        ListGoals();
                        break;
                    case "6":
                        RecordEvent();
                        break;
                    case "7":
                        Console.WriteLine($"\nTotal score: {_score} pts");
                        break;
                    case "8":
                        SaveGoals();
                        break;
                    case "9":
                        LoadGoals();
                        break;
                    case "10":
                        Console.WriteLine("\nGoodbye!");
                        return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private static void CreateSimpleGoal()
        {
            Console.WriteLine("\n=== Create a Simple Goal ===");
            Console.WriteLine("(Completes once and awards points)\n");

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Description: ");
            string description = Console.ReadLine() ?? string.Empty;
            int points = ReadInt("Points: ", 0);

            SimpleGoal newGoal = new SimpleGoal(name, description, points);
            _goals.Add(newGoal);
            
            Console.WriteLine("✓ Simple goal created!");
        }

        private static void CreateEternalGoal()
        {
            Console.WriteLine("\n=== Create an Eternal Goal ===");
            Console.WriteLine("(Never completes, awards points every time)\n");

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Description: ");
            string description = Console.ReadLine() ?? string.Empty;
            int points = ReadInt("Points per event: ", 0);

            EternalGoal newGoal = new EternalGoal(name, description, points);
            _goals.Add(newGoal);
            
            Console.WriteLine("✓ Eternal goal created!");
        }

        private static void CreateChecklistGoal()
        {
            Console.WriteLine("\n=== Create a Checklist Goal ===");
            Console.WriteLine("(Complete multiple times, get bonus when done)\n");

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Description: ");
            string description = Console.ReadLine() ?? string.Empty;
            int pointsPerEvent = ReadInt("Points per event: ", 0);
            int targetCount = ReadInt("How many times to complete: ", 1);
            int bonusPoints = ReadInt("Bonus points on completion: ", 0);

            ChecklistGoal newGoal = new ChecklistGoal(name, description, pointsPerEvent, targetCount, bonusPoints);
            _goals.Add(newGoal);
            
            Console.WriteLine("✓ Checklist goal created!");
        }

        private static void CreateNegativeGoal()
        {
            Console.WriteLine("\n=== Create a Negative Goal ===");
            Console.WriteLine("(Lose points when you do something bad)\n");

            Console.Write("Name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Description: ");
            string description = Console.ReadLine() ?? string.Empty;
            int penaltyPoints = ReadInt("Penalty points: ", 0);

            NegativeGoal newGoal = new NegativeGoal(name, description, penaltyPoints);
            _goals.Add(newGoal);
            
            Console.WriteLine("✓ Negative goal created!");
        }

        private static void ListGoals()
        {
            Console.WriteLine("\n=== Your Goals ===");
            if (_goals.Count == 0)
            {
                Console.WriteLine("(no goals)");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
            }
        }

        private static void RecordEvent()
        {
            Console.WriteLine("\n=== Record an Event ===");
            if (_goals.Count == 0)
            {
                Console.WriteLine("(no goals)");
                return;
            }

            ListGoals();
            int index = ReadInt("\nEnter goal number: ", 1, _goals.Count) - 1;
            
            int awarded = _goals[index].RecordEvent();
            _score += awarded;

            if (awarded == 0)
            {
                Console.WriteLine("No points (already complete)");
            }
            else
            {
                Console.WriteLine($"✓ +{awarded} pts for \"{_goals[index].Name}\"");
                if (_goals[index].IsCompleted)
                {
                    Console.WriteLine("  Goal completed!");
                }
            }
            Console.WriteLine($"Total score: {_score} pts");
        }



        private static void SaveGoals()
        {
            List<string> lines = new List<string>();
            lines.Add(_score.ToString());

            foreach (Goal goal in _goals)
            {
                GoalSaveModel model = goal.ToSaveModel();
                string line = $"{model.Type}|{model.Name}|{model.Description}|{model.Points}|{model.IsCompleted}|{model.TargetCount}|{model.CurrentCount}|{model.BonusPoints}";
                lines.Add(line);
            }

            File.WriteAllLines(SaveFile, lines);
            Console.WriteLine($"\n✓ Saved to {SaveFile}");
        }

        private static void LoadGoals()
        {
            if (!File.Exists(SaveFile))
            {
                Console.WriteLine($"\nNo save file found at {SaveFile}");
                return;
            }

            string[] lines = File.ReadAllLines(SaveFile);
            if (lines.Length == 0) return;

            _goals.Clear();
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool isCompleted = bool.Parse(parts[4]);

                Goal goal = type switch
                {
                    "Simple" => new SimpleGoal(name, description, points, isCompleted),
                    "Eternal" => new EternalGoal(name, description, points),
                    "Checklist" => new ChecklistGoal(name, description, points, int.Parse(parts[5]), int.Parse(parts[7]), int.Parse(parts[6]), isCompleted),
                    "Negative" => new NegativeGoal(name, description, points),
                    _ => null
                };

                if (goal != null) _goals.Add(goal);
            }

            Console.WriteLine($"\n✓ Loaded from {SaveFile}");
            Console.WriteLine($"   Goals: {_goals.Count}, Score: {_score} pts");
        }

        private static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value >= min && value <= max)
                {
                    return value;
                }
                Console.WriteLine($"Please enter an integer between {min} and {max}.");
            }
        }
    }
}