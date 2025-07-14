public class Entry
{
    public string _date = "";
    public string _textPrompt = "";
    public string _textEntry = "";
    
    // Constructor to initialize the entry
    public Entry(string prompt, string entryText)
    {
        _date = DateTime.Now.ToShortDateString();
        _textPrompt = prompt;
        _textEntry = entryText;
    }
    
    // Default constructor
    public Entry()
    {
        _date = DateTime.Now.ToShortDateString();
        _textPrompt = "";
        _textEntry = "";
    }
    
    public void DisplayEntry()
    {
        Console.WriteLine($"{_date}");
        Console.WriteLine($"{_textPrompt}");
        Console.WriteLine($"{_textEntry}");
    }  
}
