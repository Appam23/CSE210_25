using System;

public class Comment
{
        private string _authorName;
        private string _text;

        public Comment(string authorName, string text)
    {
        _authorName = authorName;
        _text = text;
    }
        public string AuthorName => _authorName;
        public string Text => _text;

        public override string ToString()
        {
            return $"{AuthorName}: {Text}";
        }
}
