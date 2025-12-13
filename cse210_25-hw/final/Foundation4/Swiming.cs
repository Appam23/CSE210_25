using System;

namespace FitnessTracker
{
    public class Swimming : Activity
    {
        private int _laps;

        public Swimming(DateTime date, int minutes, int laps)
            : base(date, minutes)
        {
            _laps = laps;
        }

        public int Laps => _laps;

        public override double GetDistance()
        {
            // Distance (miles) = laps * 50 / 1000 * 0.62
            return _laps * 50.0 / 1000.0 * 0.62;
        }

        public override string GetSummary()
        {
            return $"{Date:dd MMM yyyy} Swimming ({Minutes} min) - Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
        }
    }
}