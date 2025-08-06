namespace Mindfulness
{
    class Listing : Activity

    {
        private List<string> _userInputs;
        private string _userInput;

        public Listing(string activityName, string description, int duration, int animation1Pause, int animation2Pause, string prompts) : base(activityName, description, duration, animation1Pause, animation2Pause, prompts)
        {
            _userInputs = new List<string>();
            _userInput = string.Empty;
        }
         public void SetUserInput()
        {   
            Console.Write("> ");
            _userInput = Console.ReadLine()?.Trim() ?? string.Empty;
            
            // Only add non-empty inputs
            if (!string.IsNullOrWhiteSpace(_userInput))
            {
                _userInputs.Add(_userInput);
                Console.WriteLine($"Added: {_userInput}");
            }
            else
            {
                Console.WriteLine("(Empty input - try again)");
            }
        }
       public void GetUserInput()
        {
            if (_userInputs.Count == 0)
            {
                Console.WriteLine("No items were listed.");
                return;
            }

            Console.WriteLine($"\nYou listed {_userInputs.Count} item(s):");
            Console.WriteLine(new string('-', 30));
            
            for (int i = 0; i < _userInputs.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_userInputs[i]}");
            }
        }
        public void ListingActivity()
        {
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);
            ShowRandomPrompts();
            Thread.Sleep(3000);
            Console.WriteLine("Get ready to list as many objects you can related to this question. Press Enter after typing each object.");
            Thread.Sleep(3000);
            ShowAnimation1();

            while (DateTime.Now < endTime)
            {

                SetUserInput();
                
            }
            Console.Clear();
            ShowAnimation2();
            Console.WriteLine("Here's what you listed.");
            GetUserInput();
        }
    }
}