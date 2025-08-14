using System;
    public class Swimming : Activity
    {
        private int _numbOfLaps;
        public Swimming(DateTime date, int lengthInMinutes, int numbOfLaps) : base(date, lengthInMinutes)
        {
            _numbOfLaps = numbOfLaps;
        }
        public override float GetDistance()
        {
            return _numbOfLaps * 50f / 1000f * 0.62f;
        }
        
    }
