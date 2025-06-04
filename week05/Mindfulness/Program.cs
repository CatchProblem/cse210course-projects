using System;

class Program
{
    static void Main(string[] args)
    {
        MindfulnessLog log = new MindfulnessLog();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice: ");

            string input = Console.ReadLine();

            Activity activity = null;

            switch (input)
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
                    log.DisplayLog();
                    continue;
                case "5":
                    running = false;
                    continue;
                default:
                    Console.WriteLine("Invalid input. Press enter to try again.");
                    Console.ReadLine();
                    continue;
            }

            activity.PerformActivity();
            log.AddEntry(activity.GetType().Name, activity.Duration);
        }

        Console.WriteLine("Goodbye!");
    }
}
