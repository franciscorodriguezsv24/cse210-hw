using System;

class Program
{
    static void Main(string[] args)
    {
        ActivityLog.LoadLog();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    ActivityLog.DisplayLog();
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                    continue;
                case "5":
                    ActivityLog.SaveLog();
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press Enter to continue.");
                    Console.ReadLine();
                    continue;
            }

            activity.Start();
            ActivityLog.RecordActivity(activity.Name);
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }
    }
}
