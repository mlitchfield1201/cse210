using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());
        int userGuess;
        int tries = 0;

        do
        {
            Console.Write("What is your guess? ");
            userGuess = int.Parse(Console.ReadLine());
            tries++;

            if (userGuess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (userGuess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
        }
        while (userGuess != magicNumber);
        Console.WriteLine("You guessed it!");
        Console.WriteLine($"It took you {tries} tries to guess the magic number.");
    }
}