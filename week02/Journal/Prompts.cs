using System;
using System.Collections.Generic;
using System.IO;

public class Prompt
{
    private string promptsFile;
    public List<string> _prompts = new List<string>();
    private bool started = false;

    public void Start()
    {
        if (started)
            return;

        Console.Write("Press <Enter> for the default file (prompts.txt) or enter a different prompts filename: ");
        promptsFile = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(promptsFile))
            promptsFile = "prompts.txt";

        if (!File.Exists(promptsFile))
            File.Create(promptsFile).Close();

        _prompts = new List<string>(File.ReadAllLines(promptsFile));

        started = true;
    }

    public void DisplayPrompts()
    {
        for (int i = 0; i < _prompts.Count; i++)
        {
            Console.WriteLine($"{i}. {_prompts[i]}");
        }
    }

    public void AddPrompt()
    {
        Console.Write("Enter new prompt: ");
        string newPrompt = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(newPrompt))
        {
            _prompts.Add(newPrompt);
            File.WriteAllLines(promptsFile, _prompts);
        }
    }

    public void DeletePrompt()
    {
        DisplayPrompts();
        Console.Write("Enter prompt number to delete: ");
        int index;

        if (int.TryParse(Console.ReadLine(), out index))
        {
            index--;

            if (index >= 0 && index < _prompts.Count)
            {
                _prompts.RemoveAt(index);
                File.WriteAllLines(promptsFile, _prompts);
            }
        }
    }
}