class Scripture
{
    private Refrence _reference;
    private List<Word> _words;

    public Scripture(Refrence reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        // Split the text into words and create Word objects
        string[] wordArray = text.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        // Create a list of indices for words that are NOT hidden
        List<int> availableIndices = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                availableIndices.Add(i);
            }
        }
        
        // Don't try to hide more words than are available
        int wordsToHide = Math.Min(numberToHide, availableIndices.Count);
        
        Random random = new Random();
        
        // Hide the specified number of words by randomly selecting from available words
        for (int i = 0; i < wordsToHide; i++)
        {
            // Pick a random index from the available unhidden words
            int randomListIndex = random.Next(availableIndices.Count);
            int wordIndex = availableIndices[randomListIndex];
            
            // Hide the word
            _words[wordIndex].Hide();
            
            // Remove this index from available list so we don't pick it again
            availableIndices.RemoveAt(randomListIndex);
        }
    }

    public string GetDisplayText()
    {
        string displayText = _reference.GetScriptureRefrence() + " ";
        
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        
        return displayText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}