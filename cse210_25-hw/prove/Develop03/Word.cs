class Word
{
    private string _word;
    private bool _isHidden;

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _word.Length);
        }
        else
        {
            return _word;
        }
    }

    public string HideWord()
    {
        int Length = _word.Length;
        string hiddenword = new string('_', Length);
        return hiddenword;
    }
}
