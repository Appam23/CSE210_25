using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string referenceText)
    {
        // Parse reference like "John 3:16" or "Proverbs 3:5-6"
        ParseReference(referenceText);
    }

    private void ParseReference(string referenceText)
    {
        try
        {
            // Split book and chapter:verse
            string[] parts = referenceText.Split(' ');
            _book = parts[0];
            
            string chapterVerse = parts[1];
            string[] chapterVerseParts = chapterVerse.Split(':');
            _chapter = int.Parse(chapterVerseParts[0]);
            
            // Handle verse range (e.g., "5-6") or single verse ("16")
            if (chapterVerseParts[1].Contains('-'))
            {
                string[] verses = chapterVerseParts[1].Split('-');
                _startVerse = int.Parse(verses[0]);
                _endVerse = int.Parse(verses[1]);
            }
            else
            {
                _startVerse = int.Parse(chapterVerseParts[1]);
                _endVerse = _startVerse;
            }
        }
        catch
        {
            // Default values if parsing fails
            _book = "Unknown";
            _chapter = 1;
            _startVerse = 1;
            _endVerse = 1;
        }
    }

    public override string ToString()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}