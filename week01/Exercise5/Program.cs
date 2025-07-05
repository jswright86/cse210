using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int square = SquareNumber(number);
        DisplayResult(name, square);

    }
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber()
    {
        Console.WriteLine("Please enter you favorite number:");
        string textfavnum = Console.ReadLine();
        int number = int.Parse(textfavnum);
        return number;
    }
    static int SquareNumber(int number)
    {
        int sum = number * number;
        return sum;
    }
    static void DisplayResult(string name, int sum)
    {
        Console.WriteLine($"{name}, the square of your number is {sum}");
    }
    
}
    