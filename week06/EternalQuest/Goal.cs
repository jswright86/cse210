using System.Data;
using System.Dynamic;
using System.Reflection.Metadata;

namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;


        }
        public abstract void RecordEvent();
        public abstract bool IsComplete();
        public string GetDetails()
        {
            return $"{_name} {_description} {_points}";
        }
        public int GetPoints()
        {
            return _points;
        }


        public abstract string GetStringRepresentation();
        public string GetName()
        {
            return _name;
        }
        public string GetDescription()
        {
            return _description;
        }
    }
}