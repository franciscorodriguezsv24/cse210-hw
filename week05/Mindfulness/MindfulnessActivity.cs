using System;
using System.Threading;

abstract class MindfulnessActivity
{
    public string Name { get; protected set; }
    protected string Description;
    protected int Duration;

    public void Start()
    {
        DisplayStartingMessage();
        PrepareToBegin();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Starting {Name}...");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(3);
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed the {Name} for {Duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "/", "-", "\\", "|" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int idx = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[idx]);
            Thread.Sleep(250);
            Console.Write("\b");
            idx = (idx + 1) % spinner.Length;
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void PrepareToBegin()
    {
        Console.WriteLine("Prepare...");
        ShowCountdown(3);
    }

    protected abstract void PerformActivity();
}
