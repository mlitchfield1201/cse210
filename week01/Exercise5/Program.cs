using System;

class Program
{
    static void Main(string[] args)
    {
        static void Welcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string GetUserName()
        {
            Console.Write("Please enter your name: ");
            return Console.ReadLine();
        }

        static int GetFavoriteNumber()
        {
            Console.Write("Please enter your favorite number: ");
            return int.Parse(Console.ReadLine());
        }

        static int GetSquareNumber(int number)
        {
            return number * number;
        }

        static string ComposeMessage(string name, int number)
        {
            return $"{name}, the square of your number is {number}";
        }

        Welcome();
        string userName = GetUserName();
        int favoriteNumber = GetFavoriteNumber();
        int squaredNumber = GetSquareNumber(favoriteNumber);
        string message = ComposeMessage(userName, squaredNumber);
        Console.WriteLine(message);
    }
}