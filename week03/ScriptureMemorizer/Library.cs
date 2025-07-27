using System;

class Library
{
    private Scripture _scripture;
    private Reference _reference;
    private static Random _random = new Random();
    private static int _lastScriptureIndex = -1;

    private static readonly (string book, int chapter, int startVerse, int endVerse, string text)[] scriptures =
    {
        ("Proverbs", 3, 5, 6, "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths."),
        ("John", 3, 16, 16, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
        ("Philippians", 4, 13, 13, "I can do all things through Christ which strengtheneth me."),
        ("Psalms", 23, 1, 1, "The Lord is my shepherd; I shall not want."),
        ("Romans", 8, 28, 28, "And we know that all things work together for good to them that love God, to them who are the called according to his purpose."),
        ("Joshua", 1, 9, 9, "Have not I commanded thee? Be strong and of a good courage; be not afraid, neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest.")
    };

    
    public Library()
    {
        LoadRandomScripture();
    }

    // Method to load a random scripture (avoiding immediate repetition)
    public void LoadRandomScripture()
    {
        int newIndex;
        do
        {
            newIndex = _random.Next(scriptures.Length);
        } while (newIndex == _lastScriptureIndex && scriptures.Length > 1);
        
        _lastScriptureIndex = newIndex;
        var selected = scriptures[newIndex];
        
        _reference = new Reference(selected.book, selected.chapter, selected.startVerse, selected.endVerse);
        _scripture = new Scripture(_reference, selected.text);
    }

    // Method to get the current scripture
    public Scripture GetCurrentScripture()
    {
        return _scripture;
    }

    // Method to get the current reference
    public Reference GetCurrentReference()
    {
        return _reference;
    }

    // Method to get the display text of current scripture
    public string GetDisplayText()
    {
        return _scripture?.GetDisplayText() ?? "";
    }

    // Method to hide random words in current scripture
    public void HideRandomWords(int count)
    {
        _scripture?.HideRandomWords(count);
    }

    // Method to check if current scripture is completely hidden
    public bool IsCompletelyHidden()
    {
        return _scripture?.IsCompletelyHidden() ?? false;
    }

    // Method to get total number of scriptures available
    public static int GetScriptureCount()
    {
        return scriptures.Length;
    }

    // Method to load a specific scripture by index (for testing or specific selection)
    public void LoadScriptureByIndex(int index)
    {
        if (index >= 0 && index < scriptures.Length)
        {
            var selected = scriptures[index];
            _reference = new Reference(selected.book, selected.chapter, selected.startVerse, selected.endVerse);
            _scripture = new Scripture(_reference, selected.text);
            _lastScriptureIndex = index;
        }
    }
}