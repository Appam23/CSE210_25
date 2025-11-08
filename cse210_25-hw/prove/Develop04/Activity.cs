namespace MindfulActivities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;

    // Base class that encapsulates shared behaviour
    public abstract class Activity
    {
        protected string _startMessage;
        protected string _endMessage;
        protected TimeSpan _duration;
        private Stopwatch _stopwatch;
        private int _tickCount = 0;
        private readonly string[] _tickChars = { "🧘", "🧘‍♀️", "🧘‍♂️", "🤸", "🤸‍♀️", "🤸‍♂️" };

        protected Activity(string startMessage = "Starting activity...", string endMessage = "Activity finished.")
        {
            _startMessage = startMessage;
            _endMessage = endMessage;
            _stopwatch = new Stopwatch();
            _duration = TimeSpan.FromSeconds(60); // default
        }

        // Public API: start the activity lifecycle
        public void Start()
        {
            Console.WriteLine(_startMessage);
            StartStopwatch();
            Run();               // concrete activity behaviour implemented by subclass
            StopStopwatch();
            Console.WriteLine(_endMessage);
            // Show the activity duration, not the elapsed time (which may be longer due to processing)
            double actualElapsed = Math.Min(_stopwatch.Elapsed.TotalSeconds, _duration.TotalSeconds);
            Console.WriteLine($"Elapsed: {actualElapsed:F1}s");
        }

        // Each concrete activity implements its own Run()
        protected abstract void Run();

        // Helper: set or get duration for an activity
        public void SetDurationSeconds(int seconds)
        {
            _duration = TimeSpan.FromSeconds(seconds);
        }

        public TimeSpan ActivityDuration()
        {
            return _duration;
        }

        // Stopwatch helpers shared by all children
        protected void StartStopwatch()
        {
            _stopwatch.Restart();
        }

        protected void StopStopwatch()
        {
            _stopwatch.Stop();
        }

    protected bool TimeRemaining()
    {
        bool hasTime = _stopwatch.Elapsed < _duration;
        
        // Show ticking animation every 10 checks
        if (_tickCount % 10 == 0 && hasTime)
        {
            int charIndex = (_tickCount / 10) % _tickChars.Length;
            double remaining = (_duration - _stopwatch.Elapsed).TotalSeconds;
            // Ensure remaining doesn't show negative or 0.0
            if (remaining > 0)
            {
                Console.Write($"\r{_tickChars[charIndex]} Time: {remaining:F1}s left  ");
            }
        }
        _tickCount++;
        
        // Clear the line when time is up
        if (!hasTime)
        {
            Console.Write("\r                                    \r");
        }
        
        return hasTime;
    }        // Small utility to wait while printing a simple countdown (non-blocking for demo)
        protected void Countdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                if (i > 1) Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}