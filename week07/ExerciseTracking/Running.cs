using System;
namespace ExerciseTracker
{
    public class Running : Activity
    {
        private float _milesRan;
        public Running(DateTime date, int lengthInMinutes, float milesRan) : base(date, lengthInMinutes)
        {
            _milesRan = milesRan;
        }
        public override float GetDistance()
        {
            return _milesRan;
        }
    }

}