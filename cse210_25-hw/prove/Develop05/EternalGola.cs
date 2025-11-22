using System;
using System.Text.Json.Serialization;

namespace GoalTracker.Models
{
    /// An eternal goal: never completes; each recorded event awards points.
    public class EternalGoal : Goal
    {
        private readonly int _points;

        public EternalGoal(string name, string description, int points)
            : base(name, description)
        {
            _points = Math.Max(0, points);
            IsCompleted = false; // intentionally always false
        }

        [JsonConstructor]
        public EternalGoal(string name, string description, int points, bool unused = false)
            : base(name, description)
        {
            _points = Math.Max(0, points);
            IsCompleted = false;
        }

        public int Points => _points;

        public override int RecordEvent()
        {
            // Always award points; never mark complete
            return _points;
        }

        public override string GetStatus()
        {
            return $"[ ] (Eternal) {Name} - {Description} (+{_points} pts each)";
        }

        public override GoalSaveModel ToSaveModel()
        {
            return new GoalSaveModel
            {
                Type = "Eternal",
                Name = Name,
                Description = Description,
                IsCompleted = false,
                Points = _points
            };
        }
    }
}