using System;
using System.Text.Json.Serialization;

namespace GoalTracker.Models
{

    /// A one-time goal: awards points once and then is complete.

    public class SimpleGoal : Goal
    {
        private readonly int _points;
        private bool _completed;

        // Primary constructor used when creating new goals
        public SimpleGoal(string name, string description, int points)
            : base(name, description)
        {
            _points = Math.Max(0, points);
            _completed = false;
            IsCompleted = _completed;
        }

        // Constructor used by JSON deserializers to restore state (optional)
        [JsonConstructor]
        public SimpleGoal(string name, string description, int points, bool completed)
            : base(name, description)
        {
            _points = Math.Max(0, points);
            _completed = completed;
            IsCompleted = _completed;
        }

        public int Points => _points;

        public override int RecordEvent()
        {
            if (_completed) return 0;
            _completed = true;
            IsCompleted = true;
            return _points;
        }

        public override string GetStatus()
        {
            string check = _completed ? "[X]" : "[ ]";
            return $"{check} (Simple) {Name} - {Description} ({_points} pts)";
        }

        public override GoalSaveModel ToSaveModel()
        {
            return new GoalSaveModel
            {
                Type = "Simple",
                Name = Name,
                Description = Description,
                IsCompleted = _completed,
                Points = _points
            };
        }
    }
}