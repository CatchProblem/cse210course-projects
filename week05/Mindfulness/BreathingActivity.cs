using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly.";
    }

    protected override void ExecuteActivity()
    {
        int cycle = Duration / 6;
        for (int i = 0; i < cycle; i++)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(3);
            Console.WriteLine();
            Console.Write("Breathe out... ");
            ShowCountdown(3);
            Console.WriteLine();
        }
    }
}
