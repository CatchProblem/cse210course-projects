using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can.";
    }

    protected override void ExecuteActivity()
    {
        Random rnd = new Random();
        Console.WriteLine(_prompts[rnd.Next(_prompts.Count)]);
        Console.WriteLine("You may begin listing items in: ");
        ShowCountdown(5);

        List<string> entries = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(entry))
                entries.Add(entry);
        }

        Console.WriteLine($"You listed {entries.Count} items.");
    }
}
