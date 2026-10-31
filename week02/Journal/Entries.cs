using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    private static Random rand = new Random();
     private string promptsFile;
    public List<string> _prompts;

    private string entriesFile;
    public List<string> _entries;
    public void Start()
{
    Console.WriteLine("The default prompt file is 'prompts.txt.' Hit return to continue to use it. To use a different file, type it here:");
    string fileChoice = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(fileChoice))
    {
        promptsFile = "prompts.txt";
    }
    else
    {
        promptsFile = fileChoice.Trim();
        if (!File.Exists(promptsFile))
        {
            File.Create(promptsFile).Close();
        }
    }

    _prompts = new List<string>(File.ReadAllLines(promptsFile));

    Console.WriteLine("The default journal file is 'journal.txt.' Hit return to continue to use it. To use a different file, type it here:");
    string jFileChoice = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(jFileChoice))
    {
        entriesFile = "journal.txt";
    }
    else
    {
        entriesFile = jFileChoice.Trim();
        if (!File.Exists(entriesFile))
        {
            File.Create(entriesFile).Close();
        }
    }

    _entries = new List<string>(File.ReadAllLines(entriesFile));
}

public void ChangeFile()
{
    Console.Write("Enter a new journal file name (or press Enter to keep journal.txt): ");
    string fileChoice = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(fileChoice))
    {
        return;
    }

    entriesFile = fileChoice.Trim();

    if (!File.Exists(entriesFile))
    {
        File.Create(entriesFile).Close();
    }

    _entries = new List<string>(File.ReadAllLines(entriesFile));
}

    public void DisplayEntries()
    {
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"{i} - {_entries[i]}");    
        }
        
    }

    public void AddEntry()
    {
        Console.Write("Do you want to write <w>ith or with<o>ut a prompt? ");
        string promptChoice = Console.ReadLine();
        if (promptChoice == "w")
        {
            int number = rand.Next(0, _prompts.Count);
            string todaysPrompt = _prompts[number];
            Console.WriteLine(todaysPrompt);
            Console.WriteLine();
            Console.Write("> ");
            string newEntry = Console.ReadLine();
            DateTime theCurrentTime = DateTime.Now;
            string dateText = theCurrentTime.ToShortDateString();
            _entries.Add($"{dateText}: [{todaysPrompt}] - {newEntry}");
            File.WriteAllLines(entriesFile, _entries);
        } else if (promptChoice == "o")
        {
            Console.WriteLine();
            Console.Write("> ");
            string newEntry = Console.ReadLine();
            DateTime theCurrentTime = DateTime.Now;
            string dateText = theCurrentTime.ToShortDateString();
            _entries.Add($"{dateText}: [no prompt] - {newEntry}");
            File.WriteAllLines(entriesFile, _entries);
        }
        
    }


    public void DeleteEntry()
    {
        Console.Write("Which numbered entry do you want to permanently delete? ");
        string oldEntry = Console.ReadLine();
        int oldEntryNumber = int.Parse(oldEntry);
        _entries.RemoveAt(oldEntryNumber);
        File.WriteAllLines(entriesFile, _entries);
    }

}