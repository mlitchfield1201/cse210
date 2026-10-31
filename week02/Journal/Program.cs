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
        Entry entry1 = new Entry();

        string choice = "";

        while (choice != "x")
        {
            Console.WriteLine("Do you want the <p>rompt menu, the <j>ournal menu, or to e<x>it?");
            choice = Console.ReadLine();

            if (choice == "p" || choice == "P")
            {
                prompt1.Start();

                string promptChoice = "";
                while (promptChoice != "x")
                {
                    Console.WriteLine("Prompt Menu");
                    Console.WriteLine("1. Display all prompts");
                    Console.WriteLine("2. Add a new prompt");
                    Console.WriteLine("3. Remove a prompt");
                    Console.WriteLine("x. Back");
                    promptChoice = Console.ReadLine();

                    if (promptChoice == "1")
                        prompt1.DisplayPrompts();
                    else if (promptChoice == "2")
                        prompt1.AddPrompt();
                    else if (promptChoice == "3")
                        prompt1.DeletePrompt();
                }
            }
            else if (choice == "j" || choice == "J")
            {
                entry1.Start();

                string journalChoice = "";
                while (journalChoice != "x")
                {
                    Console.WriteLine("Journal Menu");
                    Console.WriteLine("1. Display all journal entries");
                    Console.WriteLine("2. Add a new journal entry");
                    Console.WriteLine("3. Remove a journal entry");
                    Console.WriteLine("x. Back");
                    journalChoice = Console.ReadLine();

                    if (journalChoice == "1")
                        entry1.DisplayEntries();
                    else if (journalChoice == "2")
                        entry1.AddEntry();
                    else if (journalChoice == "3")
                        entry1.DeleteEntry();
                }
            }
        }
    }
}