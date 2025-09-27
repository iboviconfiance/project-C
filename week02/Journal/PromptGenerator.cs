using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who is the most interesting person I interacted with today?",
        "What was the best moment of my day?",
        "How have I seen the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do again today, what would it be?"
    };

    public string GetRandomPrompt()
    {
        Random rnd = new Random();
        int index = rnd.Next(_prompts.Count);
        return _prompts[index];
    }
}
