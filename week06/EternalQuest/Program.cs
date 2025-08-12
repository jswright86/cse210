using System;
using EternalQuest;

class Program
{
    static void Main(string[] args)
    {
        GoalManager gm = new GoalManager();
        string input = "";
        
        Console.WriteLine("Welcome to the Eternal Quest Goal Tracker!");
        Console.WriteLine();
        
        while (input != "6")
        {
            Console.Clear();
            gm.Start();
            Console.Write("Select a choice from the menu: ");
            input = Console.ReadLine();
            
            if (input == "1")
            {
                Console.Clear();
                gm.CreateGoal();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.WriteLine("Your Goals:");
                gm.ListGoalDetails(); 
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            else if (input == "3")
            {
                Console.Clear();
                gm.SaveGoals();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            else if (input == "4")
            {
                Console.Clear();
                gm.LoadGoals();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            else if (input == "5")
            {
                Console.Clear();
                gm.RecordEvent();
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            else if (input == "6")
            {
                Console.WriteLine("Thank you for using the Eternal Quest Goal Tracker!");
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please select a number between 1 and 6.");
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}