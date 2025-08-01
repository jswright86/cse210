using System;
using Homework;

class Program
{
    static void Main(string[] args)
    {
        Assignments assignment = new Assignments("Wright", "Joshua", "Multiplication");
        Console.WriteLine(assignment.GetSummary());
        Console.WriteLine();

        MathAssignments mathAssignment = new MathAssignments("Rodriguez", "Roberto", "Fractions", "Section 7.3", "Problems 8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine();

        WritingAssignments writingAssignment = new WritingAssignments("Waters", "Mary", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
        
    }
    
}