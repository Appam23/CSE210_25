using System;
using System.Collections.Generic;

namespace FitnessTracker
{
    class Program
    {
        static void Main()
        {
            // Create activities
            Running running = new Running(new DateTime(2022, 11, 3), 30, 3.0);
            Cycling cycling = new Cycling(new DateTime(2022, 11, 4), 45, 15.0);
            Swimming swimming = new Swimming(new DateTime(2022, 11, 5), 40, 30);

            // Put all activities in a list
            List<Activity> activities = new List<Activity>();
            activities.Add(running);
            activities.Add(cycling);
            activities.Add(swimming);

            // Iterate and display summaries
            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}