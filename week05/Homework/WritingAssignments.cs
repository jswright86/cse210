namespace Homework
{
    public class WritingAssignments : Assignments
    {
        private string _title;
        public string GetTitle()
        {
            return _title;
        }
        public string GetWritingInformation()
        {
            return $"{GetTitle()} by {GetName()}";
        }
        public WritingAssignments(string lastName, string firstName, string topic, string title) : base(lastName, firstName, topic)
        {
            _title = title;
        }

        
        
        
}



}
