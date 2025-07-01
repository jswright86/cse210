using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is you grade percentage?");
        string grade = Console.ReadLine();
        int num = int.Parse(grade);

        if (num >= 90)

        {
            grade = "A";
        }
        else if (num >= 80)
        {
            grade = "B";
        }
        else if (num >= 70)
        {
            grade = "C";
        }
        else if (num >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }
        if (grade == "F")
        {
            Console.Write($"Sorry you recieved an {grade}. Don't give up! Try again next semester.");
        }
        else if (grade == "A")
        {
            Console.Write($"Congratulations! You Passed with an {grade}!");
        }
        else
        {
            Console.Write($"Congratulations! You Passed with a {grade}!");
        }
        
        } }
       
