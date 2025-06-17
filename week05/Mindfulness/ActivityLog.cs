using System;
using System.Collections.Generic;
using System.IO;

static class ActivityLog
{
    private static Dictionary<string, int> log = new Dictionary<string, int>();

    public static void RecordActivity(string activityName)
    {
        if (log.ContainsKey(activityName))
            log[activityName]++;
        else
            log[activityName] = 1;
    }

    public static void DisplayLog()
    {
        Console.WriteLine("\nActivity Log:");
        foreach (var entry in log)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} times");
        }
    }

    public static void SaveLog()
    {
        using (StreamWriter writer = new StreamWriter("activity_log.txt"))
        {
            foreach (var entry in log)
            {
                writer.WriteLine($"{entry.Key},{entry.Value}");
            }
        }
    }

    public static void LoadLog()
    {
        if (!File.Exists("activity_log.txt"))
            return;

        foreach (var line in File.ReadAllLines("activity_log.txt"))
        {
            var parts = line.Split(',');
            if (parts.Length == 2)
            {
                log[parts[0]] = int.Parse(parts[1]);
            }
        }
    }
}
