using System;
using System.Text.Json.Serialization;

namespace GoalTracker.Models
{
    
    /// Each record awards pointsPerEvent; on final required occurrence award extra bonus.
  
    public class ChecklistGoal : Goal
    {
        private readonly int _pointsPerEvent;
        private readonly int _targetCount;
        private readonly int _bonusPoints;
        private int _currentCount;

        // Constructor for creating new checklist goals
        public ChecklistGoal(string name, string description, int pointsPerEvent, int targetCount, int bonusPoints)
            : base(name, description)
        {
            _pointsPerEvent = Math.Max(0, pointsPerEvent);
            _targetCount = Math.Max(1, targetCount);
            _bonusPoints = Math.Max(0, bonusPoints);
            _currentCount = 0;
            IsCompleted = false;
        }

        // Constructor used for deserialization / restoring state
        [JsonConstructor]
        public ChecklistGoal(string name, string description, int pointsPerEvent, int targetCount, int bonusPoints, int currentCount, bool completed)
            : base(name, description)
        {
            _pointsPerEvent = Math.Max(0, pointsPerEvent);
            _targetCount = Math.Max(1, targetCount);
            _bonusPoints = Math.Max(0, bonusPoints);
            _currentCount = Math.Max(0, currentCount);
            IsCompleted = completed || _currentCount >= _targetCount;
        }

        public int PointsPerEvent => _pointsPerEvent;
        public int TargetCount => _targetCount;
        public int BonusPoints => _bonusPoints;
        public int CurrentCount => _currentCount;

        public override int RecordEvent()
        {
            if (IsCompleted) return 0;

            _currentCount++;
            int awarded = _pointsPerEvent;

            if (_currentCount >= _targetCount)
            {
                awarded += _bonusPoints;
                IsCompleted = true;
            }

            return awarded;
        }

    public override string GetStatus()
    {
        string check = IsCompleted ? "[X]" : "[ ]";
        return $"{check} (Checklist) {Name} - {Description} Completed {_currentCount}/{_targetCount} (+{_pointsPerEvent} pts each, bonus {_bonusPoints} pts)";
    }        public override GoalSaveModel ToSaveModel()
        {
            return new GoalSaveModel
            {
                Type = "Checklist",
                Name = Name,
                Description = Description,
                IsCompleted = IsCompleted,
                Points = _pointsPerEvent,
                TargetCount = _targetCount,
                CurrentCount = _currentCount,
                BonusPoints = _bonusPoints
            };
        }
    }
}