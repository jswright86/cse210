using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Mindfulness
{
    class Reflection : Activity
    {
        private List<string> _promptQuestions;
        private int _pause;


        public Reflection(string activityName, string description, int duration, int animation1Pause, int animation2Pause,int pause,string prompts, string promptQuestions ) : base(activityName, description, duration, animation1Pause, animation2Pause, prompts)
        {
            
            _promptQuestions = promptQuestions.Split("|").ToList();
            _pause = pause;

        }
        
        public void ShowRandomPromptQuestions()
        {
            Random random = new Random();
            string randomPrompt = _promptQuestions[random.Next(_promptQuestions.Count)];
            Console.WriteLine($"> {randomPrompt}");
        }
        public void ReflectionActivity()
        {
            ShowRandomPrompts();
            Thread.Sleep(_animation1Pause * 1000);
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration -_animation1Pause);

            while (DateTime.Now < endTime)
            {
                ShowRandomPromptQuestions();
                Thread.Sleep(_pause * 1000);
            }
        }
    }
}