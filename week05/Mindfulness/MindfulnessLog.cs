using System;
using System.Collections.Generic;

public class MindfulnessLog
{
    private List<(string activityName, int duration, DateTime timestamp)> _entries = new();

    public void AddEntry(string activityName, int duration)
    {
        _entries.Add((activityName, duration, DateTime.Now));
    }

    public void DisplayLog()
    {
        Console.Clear();
        Console.WriteLine("Activity Log:");
        if (_entries.Count == 0)
        {
            Console.WriteLine("No activities logged yet.");
        }
        else
        {
            foreach (var entry in _entries)
            {
                Console.WriteLine($"{entry.timestamp:g} - {entry.activityName} for {entry.duration} seconds");
            }
        }
        Console.WriteLine("\nPress Enter to return...");
        Console.ReadLine();
    }
}
