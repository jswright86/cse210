using System.ComponentModel;
using System.Runtime.ExceptionServices;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference Reference, string Text)
    {
        _reference = Reference;
        _words = Text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        //Gets words that aren't hidden
        var shownWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                shownWords.Add(word);
        }
        //hides specified amount
        int wordsToHide = Math.Min(numberToHide, shownWords.Count);

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomWord = random.Next(shownWords.Count);
            shownWords[randomWord].Hide();
            shownWords.RemoveAt(randomWord);
        }
    }

    public string GetDisplayText()
    {
        string wordText = "";
        for (int i = 0; i < _words.Count; i++)
        {
            wordText += _words[i].GetDisplayText();
            if (i < _words.Count - 1)
                wordText += " ";
        }
        return _reference.GetDisplayText() + " _ " + wordText;
    }
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }

        return true;

    }
    
}