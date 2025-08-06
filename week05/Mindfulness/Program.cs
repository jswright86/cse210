using System;
using Mindfulness;
using System.Threading;

public class Program
{
    static void Main(string[] args)
    {
        Breathing breathing1 = new Breathing("Breathing", "This activity will help you to have a session of deep breathing for a certain amount of time. You might find more peace and less stress hrough this exercise.", 0, 5, 5, "", "Breath In", "Breath Out");

        Reflection reflection1 = new Reflection("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life", 0, 5, 10, 20, "Think of a time when you stood up for someone else.|Think of a time when you did something really difficult.|Think of a time when you helped someone in need.|Think of a time when you did something truly selfless.", "Why was this experience meaningful to you?|Have you ever done anything like this before?|How did you get started?|How did you feel when it was complete?|What made this time different than other times when you were not as successful?|What is your favorite thing about this experience?|What could you learn from this experience that applies to other situations? What did you learn about yourself through this experience?|How can you keep this experience in mind in the future?");

        Listing listing1 = new Listing("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0, 5, 5, "Who are people that you appreciate?|What are personal strengths of yours?|Who are people that you have helped this week?|When have you felt the Holy Ghost this month?|Who are some of your personal heroes?");


        string input = "";
        while (input != "4")
        {
            Console.WriteLine("Please choose a number option(1-4)");
            Console.WriteLine();
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflections Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            input = Console.ReadLine();
            Console.Clear();

            if (input == "1")
            {
                //starts breathing activity
                breathing1.ShowOpeningMessage();
                Console.Clear();
                breathing1.BreathingActivity();
                Console.Clear();
                breathing1.ShowEndingMessage();
                Console.Clear();
            }
            else if (input == "2")
            {
                //start reflection activity
                reflection1.ShowOpeningMessage();
                Console.Clear();
                reflection1.ReflectionActivity();
                Console.Clear();
                reflection1.ShowEndingMessage();
                Console.Clear();
            }
            else if (input == "3")
            {
                //start listing activity
                listing1.ShowOpeningMessage();
                Console.Clear();
                listing1.ListingActivity();
                listing1.ShowEndingMessage();
                Console.Clear();
            }
            else if (input == "4")
            {
                Console.WriteLine("Have a great day!");
            }
            else
            {
                Console.WriteLine("Please choose a number option between 1 and 4...");
                Thread.Sleep(3000);
                Console.Clear(); 
            }
        }
        
        
        
    }
}