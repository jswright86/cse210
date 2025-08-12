namespace EternalQuest
{
    class Checklist : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        public Checklist(string name, string description, int points, int target, int bonus) : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = 0; // Initialize to 0
        }

        public override void RecordEvent()
        {
            _amountCompleted++;
            if (_amountCompleted == _target)
            {
                Console.WriteLine($"Congratulations! You completed the checklist and earned a bonus of {_bonus} points!");
                // You might want to track that bonus was awarded, or handle it in GoalManager
            }
            else
            {
                Console.WriteLine($"Progress: {_amountCompleted}/{_target} completed.");
            }
        }

        public int GetBonus()
        {
            return _bonus;
        }

        public override bool IsComplete()
        {
            return _amountCompleted >= _target; // Simplified and handles edge cases
        }

        public override string GetStringRepresentation()
        {
            string completionMark = IsComplete() ? "[X]" : "[ ]"; // Capital X for consistency
            return $"{completionMark} {GetName()} ({GetDescription()}) -- Currently completed: {_amountCompleted}/{_target}";
        }

        public int GetAmountCompleted()
        {   
            return _amountCompleted;
        }

        public void SetAmountCompleted(int amountCompleted)
        {
            _amountCompleted = amountCompleted;
        }

        public int GetTarget()
        {
            return _target;
        }
    }
}