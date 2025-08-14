using System;
namespace ExerciseTracker
{
    public class Bicycling : Activity
    {
        private float _milesBiked;
        public Bicycling(DateTime date, int lengthInMinutes, float milesBiked) : base(date, lengthInMinutes)
        {
            _milesBiked = milesBiked;
        }
        public override float GetDistance()
        {
            return _milesBiked;
        }

    }
}
