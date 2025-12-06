using System;
using System.Collections.Generic;


    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            Video v1 = new Video("The Joy of Running", "RunnerGuy", 600); // 10:00
            v1.AddComment(new Comment("Alice", "Great tips!"));
            v1.AddComment(new Comment("Bob", "Loved the pacing."));
            v1.AddComment(new Comment("Cara", "Can you show hill repeats?"));
            videos.Add(v1);

            Video v2 = new Video("Cycling Basics", "CycleQueen", 900); // 15:00
            v2.AddComment(new Comment("Dan", "Very helpful for beginners."));
            v2.AddComment(new Comment("Eve", "What bike is that?"));
            v2.AddComment(new Comment("Frank", "Nice camera work."));
            videos.Add(v2);

            Video v3 = new Video("Swimming Laps 101", "SwimCoach", 480); // 8:00
            v3.AddComment(new Comment("Gina", "Excellent demonstration of flip turns."));
            v3.AddComment(new Comment("Hank", "How many laps should a beginner do?"));
            v3.AddComment(new Comment("Ivy", "Pool was crowded when I tried this."));
            v3.AddComment(new Comment("Jake", "Thanks for the breathing tips."));
            videos.Add(v3);

            Video v4 = new Video("Marathon Training Plan", "ProCoach", 3600); // 1:00:00
            v4.AddComment(new Comment("Liam", "This plan worked for me."));
            v4.AddComment(new Comment("Maya", "How many rest days?"));
            v4.AddComment(new Comment("Noah", "Would love a printable schedule."));
            videos.Add(v4);

            // Display each video's details and comments
            foreach (Video video in videos)
            {
                Console.WriteLine("Title: " + video.Title);
                Console.WriteLine("Author: " + video.Author);
                Console.WriteLine("Length: " + video.GetLengthString() + $" ({video.LengthSeconds} sec)");
                Console.WriteLine("Number of comments: " + video.GetNumberOfComments());
                Console.WriteLine("Comments:");
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine("- " + comment.ToString());
                }
                Console.WriteLine(new string('-', 40));
            }
        }
    }
