using System;
using System.Collections.Generic;
using System.Linq;

// CREATIVITY: Badge system for milestones
public class Badge
{
    public string Name { get; }
    public string Description { get; }
    public Func<int, List<Goal>, bool> Criteria { get; }
    public bool Announced { get; set; }

    public Badge(string name, string description, Func<int, List<Goal>, bool> criteria)
    {
        Name = name;
        Description = description;
        Criteria = criteria;
        Announced = false;
    }

    public bool IsEarned(int score, List<Goal> goals) => Criteria(score, goals);

    public static List<Badge> GetDefaultBadges() => new List<Badge>
    {
        new Badge("Getting Started", "Complete your first goal.", (s, g) => g.Any(goal => goal.IsComplete())),
        new Badge("Quest Pro", "Reach 1,000 points.", (s, g) => s >= 1000),
        new Badge("Checklist Champ", "Finish a checklist goal.", (s, g) => g.Any(goal => goal is ChecklistGoal cl && cl.IsComplete())),
        new Badge("Persistence", "Complete any eternal goal 10 times.", (s, g) => g.OfType<EternalGoal>().Any(eg => eg.GetStatusString().Contains("10 times"))),
        new Badge("Bad Habit Buster", "Log a negative goal 5 times.", (s, g) => g.OfType<NegativeGoal>().Any(ng => ng.GetStatusString().Contains("5 times")))
    };
}