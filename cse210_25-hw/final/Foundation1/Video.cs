using System;
using System.Collections.Generic;


    public class Video
    {
        private string _title;
        private string _author;
        private int _lengthSeconds;
        private List<Comment> _comments;
        public Video(string title, string author, int lengthSeconds)
    
        {
            _title = title;
            _author = author;
            _lengthSeconds = lengthSeconds;
            _comments = new List<Comment>();
        }
        public string Title => _title;
        public string Author => _author;
        public int LengthSeconds => _lengthSeconds;
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }
        public int GetNumberOfComments()
        {
            return _comments.Count;
        }

        public IReadOnlyList<Comment> GetComments()
        {
            return _comments.AsReadOnly();
        }

        public string GetLengthString()
        {
            TimeSpan ts = TimeSpan.FromSeconds(_lengthSeconds);
            if (ts.Hours > 0)
            {
                return string.Format("{0}:{1:D2}:{2:D2}", ts.Hours, ts.Minutes, ts.Seconds);
            }
            return string.Format("{0}:{1:D2}", ts.Minutes, ts.Seconds);
        }
    }

        
