using System;
using System.Collections.Generic;
using System.IO;

public class Prompt
{
    private string promptsFile;
    public List<string> _prompts;
    public void Start()
    {
        promptsFile = "prompts.txt";

        if (!File.Exists(promptsFile))
        {
            File.Create(promptsFile).Close();
        }

        _prompts = new List<string>(File.ReadAllLines(promptsFile));
    }

    public void ChangeFile()
    {
        Console.Write("Enter a new prompt file name (or press Enter to keep prompts.txt): ");
        string fileChoice = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(fileChoice))
        {
            return;
        }

        promptsFile = fileChoice.Trim();

        if (!File.Exists(promptsFile))
        {
            File.Create(promptsFile).Close();
        }

        _prompts = new List<string>(File.ReadAllLines(promptsFile));
    }

    public void DisplayPrompts()
    {
        for (int i = 0; i < _prompts.Count; i++)
        {
            Console.WriteLine($"{i} - {_prompts[i]}");    
        }
        
    }

    public void AddPrompt()
    {
        Console.Write("What new prompt do you want to add? ");
        string newPrompt = Console.ReadLine();
        _prompts.Add(newPrompt);
        File.WriteAllLines(promptsFile, _prompts);
    }

    public void DeletePrompt()
    {
        Console.Write("Which numbered prompt do you want to permanently delete? ");
        string oldPrompt = Console.ReadLine();
        int oldPromptNumber = int.Parse(oldPrompt);
        _prompts.RemoveAt(oldPromptNumber);
        File.WriteAllLines(promptsFile, _prompts);
    }
}