class Refrence
{
    private string _book;
    private int _chapter;
    private string _verse;

    public Refrence(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse.ToString();
    }

    public Refrence(string book, int chapter, int startVerse, int EndVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = $"{startVerse}-{EndVerse}";
    }
    public string GetScriptureRefrence()
    {
        return $"{_book} {_chapter}:{_verse}";

    }
    public void displayScriptureRefrence()
    {
        Console.WriteLine($"{_book} {_chapter}:{_verse}");
    }
}
