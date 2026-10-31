//Extra credit: I gave the option of the user adding and deleting their own prompts
//Note: I've modified the way the user interacts with the files. Defaults are already set, but the user can choose different files at the beginning of the process. They cannot change later on.
//Class: CSE210
//Author: Malcolm Litchfield

using System;

class Program
{
    static void Main(string[] args)
    {

        Prompt prompt1 = new Prompt();
        prompt1.Start();
        Entry entry1 = new Entry();
        entry1.Start();

        Console.Write("Do you want the <p>rompt menu, the <j>ournal menu, or to e<x>it? ");
        string menuChoice = Console.ReadLine();
        while (menuChoice != "x" && menuChoice != "X")
        {
            if (menuChoice == "p" || menuChoice == "P")
            {
                Console.WriteLine("Here are the prompt options. Enter the number of your choice:");
                Console.WriteLine();
                Console.WriteLine("1. Display all current prompts");
                Console.WriteLine("2. Add a new prompt");
                Console.WriteLine("3. Remove a prompt");
                string promptMenuChoice = Console.ReadLine();

                switch (promptMenuChoice)
                {
                    case "1":
                        Console.WriteLine();
                        prompt1.DisplayPrompts();
                        break;
                    case "2":
                        Console.WriteLine();
                        prompt1.AddPrompt();
                        break;
                    case "3":
                        Console.WriteLine();
                        prompt1.DeletePrompt();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } else if (menuChoice == "j" || menuChoice == "J")
            {
                Console.WriteLine("Here are the journal entry options. Enter the number of your choice:");
                Console.WriteLine();
                Console.WriteLine("1. Display full journal");
                Console.WriteLine("2. Add a new entry");
                Console.WriteLine("3. Remove an entry");
                string promptJournalChoice = Console.ReadLine();

                switch (promptJournalChoice)
                {
                    case "1":
                        Console.WriteLine();
                        entry1.DisplayEntries();
                        break;
                    case "2":
                        Console.WriteLine();
                        entry1.AddEntry();
                        break;
                    case "3":
                        Console.WriteLine();
                        entry1.DeleteEntry();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            Console.Write("Do you want the <p>rompt menu, the <j>ournal menu, or to e<x>it? ");
            menuChoice = Console.ReadLine();

        }
    }
}