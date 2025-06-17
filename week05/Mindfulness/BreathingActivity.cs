using System;
using System.Threading;

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        Name = "Breathing Activity";
        Description = "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breathing.";
    }

    protected override void PerformActivity()
    {
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine("\nBreathe in...");
            ShowBreathingAnimation(3);
            elapsed += 3;
            if (elapsed >= Duration) break;

            Console.WriteLine("Breathe out...");
            ShowBreathingAnimation(3);
            elapsed += 3;
        }
    }

    private void ShowBreathingAnimation(int seconds)
    {
        for (int i = 1; i <= seconds; i++)
        {
            Console.WriteLine(new string('*', i));
            Thread.Sleep(1000);
        }
        for (int i = seconds; i >= 1; i--)
        {
            Console.WriteLine(new string('*', i));
            Thread.Sleep(1000);
        }
    }
}
