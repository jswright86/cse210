using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry entry)

    {
        _entries.Add(entry);
    }
    public void DisplayAllEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"\nEntry {i + 1}:");
            _entries[i].DisplayEntry();
        }
    }
    public void SaveToFile()
    {
        string filename = "journal_entries.txt";
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}|{entry._textPrompt}|{entry._textEntry}");
            }
            
        }
    }
    public void LoadFromFile()
    {
        string filename = "journal_entries.txt";
        //Checks to see if file exists
        if (File.Exists(filename))
        {
            //if file exists, load file 
            _entries.Clear();
            string[] lines = System.IO.File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");
                if (parts.Length == 3)
                {
                    Entry entry = new Entry();
                    entry._date = parts[0];
                    entry._textPrompt = parts[1];
                    entry._textEntry = parts[2];
                    _entries.Add(entry);
                }

            }
        }
        else
        //if File doesn't exist
        {
            Console.WriteLine($"No journal entries have been written and saved yet.");
        }    
    }
}
  