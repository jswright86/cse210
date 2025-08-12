namespace EternalQuest
{
    class Simple : Goal
    {
        private bool _isComplete;

        public Simple(string name, string description, int points) : base(name, description, points)
        {
            _isComplete = false; // Initialize to false
        }

        public override void RecordEvent()
        {
           
                _isComplete = true;
                Console.WriteLine($"Congratulations on completing your '{GetName()}' Goal");
                

          
        }

        public override bool IsComplete()
        {
            return _isComplete;
        }

        public override string GetStringRepresentation()
        {
            string completionMark = IsComplete() ? "[X]" : "[ ]";
            return $"{completionMark} {GetName()} ({GetDescription()})";
        }




    }
}