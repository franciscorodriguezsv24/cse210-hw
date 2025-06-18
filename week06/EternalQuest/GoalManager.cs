using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class GoalManager
{
    public List<Goal> Goals { get; private set; } = new List<Goal>();
    public int TotalPoints { get; private set; } = 0;
    public int Streak { get; private set; } = 0;
    public List<string> Badges { get; private set; } = new List<string>();

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        int points = Goals[goalIndex].RecordEvent();
        TotalPoints += points;

        if (points > 0)
            Streak++;
        else
            Streak = 0;

        CheckForBadges();

        Console.WriteLine($"You earned {points} points! Total points: {TotalPoints}");
        Console.WriteLine($"Current Streak: {Streak} days");
        Console.WriteLine($"Current Level: {GetLevel()}");
        DisplayBadges();
    }

    public void DisplayGoals()
    {
        for (int i = 0; i < Goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Goals[i].GetStatus()}");
        }
    }

    public int GetLevel()
    {
        return TotalPoints / 1000 + 1;
    }

    private void CheckForBadges()
    {
        if (TotalPoints >= 5000 && !Badges.Contains("Gold Achiever"))
            Badges.Add("Gold Achiever");

        if (Streak >= 5 && !Badges.Contains("Streak Master"))
            Badges.Add("Streak Master");
    }

    public void DisplayBadges()
    {
        if (Badges.Count > 0)
        {
            Console.WriteLine("Badges earned:");
            foreach (var badge in Badges)
            {
                Console.WriteLine($"- {badge}");
            }
        }
    }

    public void Save(string filename)
    {
        var options = new JsonSerializerOptions { WriteIndented = true, Converters = { new GoalConverter() } };
        var json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(filename, json);
    }

    public static GoalManager Load(string filename)
    {
        if (File.Exists(filename))
        {
            var json = File.ReadAllText(filename);
            var options = new JsonSerializerOptions { Converters = { new GoalConverter() } };
            return JsonSerializer.Deserialize<GoalManager>(json, options);
        }
        return new GoalManager();
    }
}