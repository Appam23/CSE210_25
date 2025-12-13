using System;

namespace EventPlanning
{
    public class OutdoorGathering : Event
    {
        private string _weatherForecast;

        public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
            : base(title, description, date, time, address)
        {
            _weatherForecast = weatherForecast;
        }

        public string WeatherForecast => _weatherForecast;

        public override string GetFullDetails()
        {
            return GetStandardDetails() +
                   $"\nType:  Outdoor Gathering" +
                   $"\nWeather Forecast:  {WeatherForecast}";
        }

        public override string GetShortDescription()
        {
            return $"Type:  Outdoor Gathering\nTitle: {Title}\nDate: {Date: MMMM dd, yyyy}";
        }
    }
}