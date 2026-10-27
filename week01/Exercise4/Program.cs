using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        string input = "";

        Console.WriteLine("Enter a list of numbers, type 0 when you are finished. ");
        do
        {
            Console.Write("Enter a number: ");
            input = Console.ReadLine();
            if (input != "0")
            {
                numbers.Add(int.Parse(input));
            }
        } while (input != "0");

        int length = numbers.Count;
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");
        double average = (double)sum / length;
        Console.WriteLine($"The average is: {average}");
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");


    }
}