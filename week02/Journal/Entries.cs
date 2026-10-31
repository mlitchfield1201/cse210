using System;
using System.Collections.Generic;
using System.IO;

public class Entry
{
    private static Random rand = new Random();
    private bool started = false;
    private string promptsFile;
    public List<string> _prompts = new List<string>();
    private string entriesFile;
    public List<string> _entries = new List<string>();

    public void Start()
    {
        if (started)
            return;

        Console.Write("Press <Enter> for the default file (prompts.txt) or enter a different prompts filename: ");
        promptsFile = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(promptsFile))
            promptsFile = "prompts.txt";

        Console.Write("Press <Enter> for the default journal file (journal.txt) or enter a different journal filename: ");
        entriesFile = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(entriesFile))
            entriesFile = "journal.txt";

        if (!File.Exists(promptsFile))
            File.Create(promptsFile).Close();

        if (!File.Exists(entriesFile))
            File.Create(entriesFile).Close();

        _prompts = new List<string>(File.ReadAllLines(promptsFile));
        _entries = new List<string>(File.ReadAllLines(entriesFile));

        started = true;
    }

    public void DisplayEntries()
    {
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"{i}. {_entries[i]}");
        }
    }

    public void AddEntry()
    {
        string prompt = "";

        Console.Write("Write <w>ith a prompt or with<o>ut a prompt? ");
        string usePrompt = Console.ReadLine();

        if ((usePrompt == "w" || usePrompt =="W") && _prompts.Count > 0)
        {
            prompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine(prompt);
        } else
        {
            prompt = "no prompt";
        }

        Console.Write("> ");
        string newEntry = Console.ReadLine();

        string dateText = DateTime.Now.ToString("yyyy-MM-dd");
        string fullEntry = $"{dateText}: [{prompt}] - {newEntry}";

        _entries.Add(fullEntry);
        File.WriteAllLines(entriesFile, _entries);
    }

    public void DeleteEntry()
    {
        DisplayEntries();
        Console.Write("Enter entry number to delete: ");
        int index;

        if (int.TryParse(Console.ReadLine(), out index))
        {
            index--;

            if (index >= 0 && index < _entries.Count)
            {
                _entries.RemoveAt(index);
                File.WriteAllLines(entriesFile, _entries);
            }
        }
    }
}