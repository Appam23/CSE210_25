using System;

namespace EventPlanning
{
    public class Reception :  Event
    {
        private string _rsvpEmail;

        public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
            : base(title, description, date, time, address)
        {
            _rsvpEmail = rsvpEmail;
        }

        public string RsvpEmail => _rsvpEmail;

        public override string GetFullDetails()
        {
            return GetStandardDetails() +
                   $"\nType: Reception" +
                   $"\nRSVP Email: {RsvpEmail}";
        }

        public override string GetShortDescription()
        {
            return $"Type: Reception\nTitle:  {Title}\nDate: {Date:MMMM dd, yyyy}";
        }
    }
}