using System;
using System.Collections.Generic;

namespace EventPlanning
{
    class Program
    {
        static void Main()
        {
            // Create addresses
            Address addr1 = new Address("100 University Ave", "Stanford", "CA", "USA");
            Address addr2 = new Address("200 Park Plaza", "New York", "NY", "USA");
            Address addr3 = new Address("500 Beach Blvd", "San Diego", "CA", "USA");

            // Create events
            Lecture lecture = new Lecture(
                "AI and the Future",
                "An exploration of artificial intelligence trends and predictions.",
                new DateTime(2025, 12, 20),
                new TimeSpan(18, 30, 0),
                addr1,
                "Dr. Appam Leisan",
                150
            );

            Reception reception = new Reception(
                "Annual Gala Dinner",
                "Join us for an evening of networking and celebration.",
                new DateTime(2025, 12, 25),
                new TimeSpan(19, 0, 0),
                addr2,
                "rsvp@gala.com"
            );

            OutdoorGathering outdoor = new OutdoorGathering(
                "Summer Music Festival",
                "Enjoy live music under the stars with food trucks and fun.",
                new DateTime(2026, 6, 15),
                new TimeSpan(17, 0, 0),
                addr3,
                "Sunny, 75°F with light breeze"
            );

            // Store in list
            List<Event> events = new List<Event> { lecture, reception, outdoor };

            // Generate and display marketing messages for each event
            foreach (Event ev in events)
            {
                Console.WriteLine("=== STANDARD DETAILS ===");
                Console.WriteLine(ev.GetStandardDetails());
                Console.WriteLine();

                Console.WriteLine("=== FULL DETAILS ===");
                Console.WriteLine(ev.GetFullDetails());
                Console.WriteLine();

                Console.WriteLine("=== SHORT DESCRIPTION ===");
                Console.WriteLine(ev.GetShortDescription());
                Console. WriteLine();

                Console.WriteLine(new string('-', 60));
                Console.WriteLine();
            }
        }
    }
}