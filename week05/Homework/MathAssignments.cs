using System.ComponentModel;

namespace Homework
{
    class MathAssignments : Assignments
    {
        private string _textbookSection;
        private string _problems;

        public string GetTextbookSection()
        {
            return _textbookSection;
        }

        public string GetProblems()
        {
            return _problems;
        }

        // show textbook section and problems
        public string GetHomeworkList()
        {
            return $"{GetTextbookSection()} {GetProblems()}";
        }

    
        public MathAssignments(string lastName, string firstName, string topic, string textbookSection, string problems) 
            : base(lastName, firstName, topic)
        {
            _textbookSection = textbookSection;
            _problems = problems;
            
        }

       
        
    }
}