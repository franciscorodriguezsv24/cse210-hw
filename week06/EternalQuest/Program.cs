using System;

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record an event");
            Console.WriteLine("3. Display goals");
            Console.WriteLine("4. Display total score");
            Console.WriteLine("5. Save goals");
            Console.WriteLine("6. Load goals");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    manager.DisplayGoals();
                    Console.Write("Which goal did you complete? ");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(index);
                    break;
                case "3":
                    manager.DisplayGoals();
                    break;
                case "4":
                    Console.WriteLine($"Total Score: {manager.TotalPoints}");
                    Console.WriteLine($"Current Level: {manager.GetLevel()}");
                    manager.DisplayBadges();
                    break;
                case "5":
                    manager.Save("goals.json");
                    Console.WriteLine("Goals saved.");
                    break;
                case "6":
                    manager = GoalManager.Load("goals.json");
                    Console.WriteLine("Goals loaded.");
                    break;
                case "7":
                    exit = true;
                    break;
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nSelect Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");
        Console.Write("Choice: ");
        string type = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter point value: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                manager.AddGoal(new SimpleGoal(name, points));
                break;
            case "2":
                manager.AddGoal(new EternalGoal(name, points));
                break;
            case "3":
                Console.Write("How many times to complete? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points when complete: ");
                int bonus = int.Parse(Console.ReadLine());
                manager.AddGoal(new ChecklistGoal(name, points, target, bonus));
                break;
            case "4":
                manager.AddGoal(new NegativeGoal(name, points));
                break;
        }
    }
}
