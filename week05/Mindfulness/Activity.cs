using System.Configuration.Assemblies;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System;
using System.Threading;
using System.Reflection;

namespace Mindfulness
{
    class Activity
    {

        private string _activityName;
        private string _description;
        protected int _duration;
        protected int _animation1Pause;
        protected int _animation2Pause;

        protected List<string> _prompts;

        public Activity(string activityName, string description, int duration, int animation1Pause, int animation2Pause, string prompt)
        {

            _activityName = activityName;
            _description = description;
            _duration = duration;
            _animation1Pause = animation1Pause;
            _animation2Pause = animation2Pause;
            _prompts = prompt.Split("|").ToList();

        }
        public void ShowRandomPrompts()
        {
            Random random = new Random();
            string randomPrompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine(randomPrompt);
        }
        public int GetDuration()
        {
            return _duration;
        }
        public int SetDuration()
        {
            Console.WriteLine("In seconds, how long would you like the activity to be?(30 seconds minimum)");
            string length = Console.ReadLine();

            while (!int.TryParse(length, out _duration) || _duration < 30)
            {
                // Check if it's a valid number but too small
                if (int.TryParse(length, out int tempDuration) && tempDuration < 30)
                {
                    Console.WriteLine("Duration must be a minimum of 30 seconds...");
                }
                else
                {
                    Console.WriteLine("Please enter a valid positive number...");
                }
                length = Console.ReadLine();
            }

            return _duration;
        }
        public string GetPreStartMessage()
        {
            return $"Get ready your {_activityName} Activity will start in {_animation1Pause} seconds...";
        }
        public void ShowAnimation1()
        {
            for (int i = _animation1Pause; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
        public void ShowAnimation2()
        {
            for (int i = _animation2Pause; i > 0; i--)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }    
        }
   

        public void Pause()
        {
            Thread.Sleep(_animation2Pause * 1000);
        }
        public void ShowOpeningMessage()
        {
            Console.WriteLine($"Welcome to the {_activityName} Activity.");
            Console.WriteLine(_description);
            SetDuration();
            Console.WriteLine($"Perfect! prepare yourself for a {_duration} second {_activityName} activity.");
            Console.WriteLine();
            Console.WriteLine(GetPreStartMessage());
            ShowAnimation1();
        }
        public void ShowEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine($"Great Job!");
            ShowAnimation2();
            Console.WriteLine($"You completed the {_activityName} Activity in {_duration} seconds.");
            ShowAnimation2();

        }







    }
}