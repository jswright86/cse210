using System;
//added a 4th class Library. This class adds the all the other classes and handles them itself. The main program calls the library class. The library has several scriptures that it randomly chooses from.
class Program
{
    static void Main()
    {
        bool playAgain = true;
        
        while (playAgain)
        {
            // Create a new library instance (automatically loads a random scripture)
            Library library = new Library();
            string userInput = "";
            
            Console.Clear();
            Console.WriteLine(library.GetDisplayText());

            // Main scripture hiding loop
            while (userInput != "quit" && !library.IsCompletelyHidden())
            {
                Console.WriteLine("Press enter to continue or type 'quit' to finish");
                userInput = Console.ReadLine()?.ToLower() ?? "";

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.Clear();
                    library.HideRandomWords(3);
                    Console.WriteLine(library.GetDisplayText());
                }
                else if (userInput == "quit")
                {
                    Console.WriteLine("Have a great day!");
                    return; // Exit the entire program
                }
                else
                {
                    Console.WriteLine("Sorry, please press enter to continue or type 'quit' to finish");
                }
            }

            // Handle completion
            if (library.IsCompletelyHidden())
            {
                bool validResponse = false;
                while (!validResponse)
                {
                    Console.WriteLine("Congrats! All words are hidden. Were you able to memorize the scripture? (yes or no)");
                    string memorized = Console.ReadLine()?.ToLower() ?? "";

                    if (memorized == "yes")
                    {
                        Console.WriteLine("Awesome! Would you like to memorize another scripture? (yes or no)");
                        string playAgainResponse = Console.ReadLine()?.ToLower() ?? "";
                        
                        if (playAgainResponse == "yes")
                        {
                            playAgain = true;
                            validResponse = true;
                        }
                        else if (playAgainResponse == "no")
                        {
                            Console.WriteLine("Have a great day!");
                            playAgain = false;
                            validResponse = true;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, please type 'yes' or 'no'");
                        }
                    }
                    else if (memorized == "no")
                    {
                        Console.WriteLine("Would you like to try to memorize it again? (yes or no)");
                        string tryAgain = Console.ReadLine()?.ToLower() ?? "";
                        
                        if (tryAgain == "yes")
                        {
                            playAgain = true; // Will restart with a fresh scripture
                            validResponse = true;
                        }
                        else if (tryAgain == "no")
                        {
                            Console.WriteLine("Have a great day!");
                            playAgain = false;
                            validResponse = true;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, please type 'yes' or 'no'");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, please type 'yes' or 'no'");
                    }
                }
            }
        }
    }
}