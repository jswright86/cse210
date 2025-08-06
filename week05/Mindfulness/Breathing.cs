using System.Globalization;

namespace Mindfulness
{
    class Breathing : Activity
    {
        private string _breathInMessage;
        private string _breathOutMessage;

        public Breathing(string activityName, string description, int duration, int animation1Pause, int animation2Pause, string prompt, string breathInMessage, string breathOutMessage) : base(activityName, description, duration, animation1Pause, animation2Pause, prompt)
        {
            _breathInMessage = breathInMessage;
            _breathOutMessage = breathOutMessage;
        }
        public void ShowBreathIn()
        {
            Console.WriteLine("Breath In");
            ShowAnimation1();
        }
        public void ShowBreathOut()
        {
            Console.WriteLine("Breath Out");
            ShowAnimation1();
        }
        public void BreathingActivity()
        {
        

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                ShowBreathIn();
                if (DateTime.Now < endTime)
                {
                    ShowBreathOut();
                }
            }    
         
                
            
        }
        
    }
}    