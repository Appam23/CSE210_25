using System;

namespace FitnessTracker
{
    public class Cycling :  Activity
    {
        private double _speed;

        public Cycling(DateTime date, int minutes, double speed)
            : base(date, minutes)
        {
            _speed = speed;
        }

        public double Speed => _speed;

        public override double GetDistance()
        {
            return (_speed * Minutes) / 60;
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override string GetSummary()
        {
            return $"{Date:dd MMM yyyy} Cycling ({Minutes} min) - Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F1} min per mile";
        }
    }
}