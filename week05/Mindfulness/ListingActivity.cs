using System;
using System.Collections.Generic;

class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing Activity";
        Description = "This activity will help you reflect on the good things in your life by having you list as many items as you can in a certain area.";
    }

    protected override void PerformActivity()
    {
        Random rnd = new Random();
        Console.WriteLine($"\n{prompts[rnd.Next(prompts.Count)]}");
        Console.WriteLine("You will begin in...");
        ShowCountdown(3);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("List an item: ");
            string input = Console.ReadLine();
            items.Add(input);
        }

        Console.WriteLine($"\nYou listed {items.Count} items.");
    }
}
