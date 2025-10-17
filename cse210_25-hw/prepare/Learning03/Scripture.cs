using System;
using System.Collections.Generic;

public class Scripture
{
    public Reference Reference { get; private set; }
    public List<Word> Words { get; private set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = new List<Word>();
        string[] splitWords = text.Split(' ');
        for (int i = 0; i < splitWords.Length; i++)
        {
            Words.Add(new Word(splitWords[i]));
        }
    }

    public void HideRandomWords(int count = 3)
    {
        List<int> notHidden = new List<int>();
        for (int i = 0; i < Words.Count; i++)
        {
            if (!Words[i].IsHidden)
                notHidden.Add(i);
        }
        if (notHidden.Count == 0)
            return;

        Random random = new Random();
        int toHide = count < notHidden.Count ? count : notHidden.Count;
        for (int i = 0; i < toHide; i++)
        {
            int index = random.Next(notHidden.Count);
            int wordIndex = notHidden[index];
            Words[wordIndex].Hide();
            notHidden.RemoveAt(index);
        }
    }

    public bool AllHidden()
    {
        for (int i = 0; i < Words.Count; i++)
        {
            if (!Words[i].IsHidden)
                return false;
        }
        return true;
    }

    public override string ToString()
    {
        string verseText = "";
        for (int i = 0; i < Words.Count; i++)
        {
            verseText += Words[i].ToString();
            if (i < Words.Count - 1)
                verseText += " ";
        }
        return Reference.ToString() + "\n\n" + verseText + "\n";
    }
}