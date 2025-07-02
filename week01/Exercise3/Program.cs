using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        /* Question 1 & 2
        Console.WriteLine("What is the magic number?");
        string number = Console.ReadLine();
        int MagNum = int.Parse(number);

        Completed with Question 3*/
        Random randomGenerator = new Random();
        int MagNum = randomGenerator.Next(1, 100);
        int Guess = -1;
        while (MagNum != Guess)
        {
            Console.WriteLine("What is your guess?");
            string textGuess = Console.ReadLine();
            Guess = int.Parse(textGuess);
        
            if (Guess > MagNum)
            {
                Console.WriteLine("Lower");
            }
            else if (Guess < MagNum)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }  
    }
} 