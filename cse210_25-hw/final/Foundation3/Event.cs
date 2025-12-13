using System;

namespace EventPlanning
{
    public class Event
    {
        private string _title;
        private string _description;
        private DateTime _date;
        private TimeSpan _time;
        private Address _address;

        public Event(string title, string description, DateTime date, TimeSpan time, Address address)
        {
            _title = title;
            _description = description;
            _date = date;
            _time = time;
            _address = address;
        }

        public string Title => _title;
        public string Description => _description;
        public DateTime Date => _date;
        public TimeSpan Time => _time;
        public Address Address => _address;

        // Standard details:  title, description, date, time, address
        public string GetStandardDetails()
        {
            return $"Event: {Title}\n" +
                   $"Description: {Description}\n" +
                   $"Date: {Date: MMMM dd, yyyy}\n" +
                   $"Time: {Time:hh\\:mm}\n" +
                   $"Address: {Address.GetFullAddress()}";
        }

        // Full details: calls standard + adds type-specific info (override in derived classes)
        public virtual string GetFullDetails()
        {
            return GetStandardDetails() + $"\nType: General Event";
        }

        // Short description: type, title, date (override type in derived classes)
        public virtual string GetShortDescription()
        {
            return $"Type: General Event\nTitle: {Title}\nDate:  {Date:MMMM dd, yyyy}";
        }
    }
}