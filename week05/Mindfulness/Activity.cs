using System;
using System.Threading;

public abstract class Activity
{
    public int Duration { get; protected set; }
    protected string _name;
    protected string _description;

    public void PerformActivity()
    {
        ShowStartingMessage();
        PrepareToBegin();
        ExecuteActivity();
        ShowEndingMessage();
    }

    private void ShowStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
    }

    private void PrepareToBegin()
    {
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i++ % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    private void ShowEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed the {_name} for {Duration} seconds.");
        ShowSpinner(2);
    }

    protected abstract void ExecuteActivity();
}
