using System;

class Program
{
    static void Main(string[] args)
    {
        
        Journal journal1 = new Journal();
        string response = "0";

        while (response != "5")
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            response = Console.ReadLine();

            if (response == "1")
            {
                // Write a new entry
                //PromptGenerator class is called
                //Random prompt is displayed

                PromptGenerator promptGenerator = new PromptGenerator();
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"{prompt}");

                //Entry class is called 
                //Stores date, prompt used and journal entry

                Entry entry = new Entry();
                entry._date = DateTime.Now.ToShortDateString();
                entry._textPrompt = prompt;
                entry._textEntry = Console.ReadLine();




                journal1.AddEntry(entry);

            }
            else if (response == "2")
            {
                journal1.DisplayAllEntries();
            }
            else if (response == "3")
            {
                journal1.LoadFromFile();
            }
            else if (response == "4")
            {
                journal1.SaveToFile();
            }
            else if (response == "5")
            {
                Console.WriteLine("Thank you! Have a great day!");
            }
            else
            {
                Console.WriteLine("Please select a choice using the numbers 1 - 5.");
            }
        }
    }
}