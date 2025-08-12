namespace EternalQuest
{
    class Eternal : Goal
    {
        public Eternal(string name, string description, int points) : base(name, description, points)
        {
            
        }
        public override void RecordEvent()
        {
            Console.WriteLine($"Congratulations on completing your '{GetName()}' Goal");
            
        }
        public override bool IsComplete()
        {
            return false;
        }
        public override string GetStringRepresentation()
        {
            string completionMark = IsComplete() ? "[ ]" : "[ ]";
            return $"{completionMark} {GetName()} ({GetDescription()})";
        }
    }
}