using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers;
        numbers = new List<int>();
        int number = -1;
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        while (number != 0)
        {
            Console.WriteLine("Enter the number:");
            string textNumber = Console.ReadLine();
            number = int.Parse(textNumber);
            numbers.Add(number);
        }    
            Console.WriteLine(numbers.Count);
            int sum = 0;
            float avg = 0;
            int bignum = 0;
            foreach (int num in numbers)
            {
                sum += num;
                avg = ((float)sum) / (numbers.Count - 1);
                if (bignum < num)
                {
                    bignum = num;
                }
                Console.WriteLine($"The sum is: {sum}");
                Console.WriteLine($"The average is: {avg}");
                Console.WriteLine($"The largest number is: {bignum}");
            }
        
    }
}