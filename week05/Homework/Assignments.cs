namespace Homework
{
    public class Assignments
    {
        private string _lastName;
        private string _firstName;
        private string _topic;
        

        public Assignments(string lastName, string firstName, string topic)
        {
            _lastName = lastName;
            _firstName = firstName;
            _topic = topic;
            
        }

        public string GetFirstName()
        {
            return _firstName;
        }

        public string GetLastName()
        {
            return _lastName;
        }

        public string GetName()
        {
            return $"{_firstName} {_lastName}";
        }

        public string GetTopic()
        {
            return _topic;
        }
        
        
        public string GetSummary()
        {
            return $"{GetName()} - {GetTopic()}";
        }
    }
}