using System;
using System.Text.Json.Serialization;

namespace GoalTracker.Models
{
    /// Encapsulates common fields and behaviour, and defines the polymorphic API.
    
    public abstract class Goal
    {
        private readonly string _name;
        private readonly string _description;
        private bool _isCompleted;

        protected Goal(string name, string description)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _description = description ?? string.Empty;
            _isCompleted = false;
        }

        // Descriptive properties - read-only to external callers (encapsulation)
        public string Name => _name;
        public string Description => _description;

        // Derived classes can set completion; external code cannot directly modify it.
        public virtual bool IsCompleted
        {
            get => _isCompleted;
            protected set => _isCompleted = value;
        }

       
        public abstract int RecordEvent();

        
        public abstract string GetStatus();

        public abstract GoalSaveModel ToSaveModel();
    }


    /// Kept here to keep the model set compact.
   
    public class GoalSaveModel
    {
        private string _type;
        private string _name;
        private string _description;
        private bool _isCompleted;
        private int _points;
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public GoalSaveModel()
        {
            _type = "";
            _name = "";
            _description = "";
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = value; }
        }

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public int TargetCount
        {
            get { return _targetCount; }
            set { _targetCount = value; }
        }

        public int CurrentCount
        {
            get { return _currentCount; }
            set { _currentCount = value; }
        }

        public int BonusPoints
        {
            get { return _bonusPoints; }
            set { _bonusPoints = value; }
        }
    }
}