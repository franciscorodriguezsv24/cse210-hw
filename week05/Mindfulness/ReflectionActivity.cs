using System;
using System.Collections.Generic;

class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        Name = "Reflection Activity";
        Description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    }

    protected override void PerformActivity()
    {
        Random rnd = new Random();
        Console.WriteLine($"\n{prompts[rnd.Next(prompts.Count)]}");
        ShowSpinner(5);

        int elapsed = 0;
        List<string> usedQuestions = new List<string>(questions);

        while (elapsed < Duration)
        {
            if (usedQuestions.Count == 0)
                usedQuestions = new List<string>(questions);

            int idx = rnd.Next(usedQuestions.Count);
            string question = usedQuestions[idx];
            usedQuestions.RemoveAt(idx);

            Console.WriteLine($"\n{question}");
            ShowSpinner(5);
            elapsed += 5;
        }
    }
}
