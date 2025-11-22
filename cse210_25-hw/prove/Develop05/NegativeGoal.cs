using System;
using System.Text.Json.Serialization;

namespace GoalTracker.Models
{
    /// A negative goal: loses points when you do something bad (e.g., "Ate junk food")
    public class NegativeGoal : Goal
    {
        private readonly int _penaltyPoints;

        public NegativeGoal(string name, string description, int penaltyPoints)
            : base(name, description)
        {
            _penaltyPoints = Math.Max(0, penaltyPoints);
            IsCompleted = false; // Never completes
        }

        [JsonConstructor]
        public NegativeGoal(string name, string description, int penaltyPoints, bool unused = false)
            : base(name, description)
        {
            _penaltyPoints = Math.Max(0, penaltyPoints);
            IsCompleted = false;
        }

        public int PenaltyPoints => _penaltyPoints;

        public override int RecordEvent()
        {
            // Returns NEGATIVE points (penalty)
            return -_penaltyPoints;
        }

        public override string GetStatus()
        {
            return $"[!] (Negative) {Name} - {Description} (-{_penaltyPoints} pts penalty)";
        }

        public override GoalSaveModel ToSaveModel()
        {
            return new GoalSaveModel
            {
                Type = "Negative",
                Name = Name,
                Description = Description,
                IsCompleted = false,
                Points = _penaltyPoints
            };
        }
    }
}
