using System;

namespace FitnessTracker
{
    public class Activity
    {
        private DateTime _date;
        private int _minutes;

        public Activity(DateTime date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        public DateTime Date => _date;
        public int Minutes => _minutes;

        // Virtual methods to be overridden in derived classes
        public virtual double GetDistance()
        {
            return 0;
        }

        public virtual double GetSpeed()
        {
            return (GetDistance() / Minutes) * 60;
        }

        public virtual double GetPace()
        {
            return Minutes / GetDistance();
        }

        public virtual string GetSummary()
        {
            return $"{Date:dd MMM yyyy} Activity ({Minutes} min) - Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace:  {GetPace():F1} min per mile";
        }
    }
}