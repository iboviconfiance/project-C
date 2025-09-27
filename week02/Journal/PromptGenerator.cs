using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Quelle est la personne la plus intéressante avec laquelle j’ai interagi aujourd’hui ?",
        "Quel a été le meilleur moment de ma journée ?",
        "Comment ai-je vu la main du Seigneur dans ma vie aujourd’hui ?",
        "Quelle a été l’émotion la plus forte que j’ai ressentie aujourd’hui ?",
        "Si j’avais une chose que je pouvais refaire aujourd’hui, quelle serait-elle ?"
    };

    public string GetRandomPrompt()
    {
        Random rnd = new Random();
        int index = rnd.Next(_prompts.Count);
        return _prompts[index];
    }
}
