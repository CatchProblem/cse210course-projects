using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private LevelSystem _levelSystem = new LevelSystem();
    private List<Badge> _badges = new List<Badge>();

    public GoalManager()
    {
        _badges = Badge.GetDefaultBadges();
    }

    public void ShowScoreAndLevel()
    {
        int level = _levelSystem.GetLevel(_score);
        Console.WriteLine($"SCORE: {_score} | Level: {level} ({_levelSystem.GetLevelName(level)})");
    }

    public void ShowBadges(bool detailed = false)
    {
        var earned = _badges.Where(b => b.IsEarned(_score, _goals)).ToList();
        if (earned.Count == 0)
        {
            Console.WriteLine("No badges earned yet.");
        }
        else
        {
            Console.WriteLine("Badges: " + string.Join(", ", earned.Select(b => b.Name)));
            if (detailed)
            {
                foreach (var badge in earned)
                    Console.WriteLine($"- {badge.Name}: {badge.Description}");
                Console.WriteLine("Press Enter to return..."); Console.ReadLine();
            }
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Your Goals:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created.");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetStatusString()}");
            }
        }
        Console.WriteLine("Press Enter...");
        Console.ReadLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal (lose points for bad habits)");
        string type = Console.ReadLine();

        Console.Write("Goal name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;
        switch (type)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times must you complete this? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points for completion: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            case "4":
                goal = new NegativeGoal(name, description, points);
                break;
            default:
                Console.WriteLine("Invalid type.");
                return;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created! Press Enter...");
        Console.ReadLine();
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            Console.ReadLine();
            return;
        }
        Console.WriteLine("Select a goal to record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatusString()}");
        }
        int choice = int.Parse(Console.ReadLine()) - 1;
        if (choice < 0 || choice >= _goals.Count)
        {
            Console.WriteLine("Invalid choice.");
            Console.ReadLine();
            return;
        }

        int pts = _goals[choice].RecordEvent();
        if (pts > 0)
        {
            _score += pts;
            Console.WriteLine($"Congratulations! You earned {pts} points!");
        }
        else if (pts < 0)
        {
            _score += pts;
            Console.WriteLine($"Oops! You lost {-pts} points...");
        }
        else
        {
            Console.WriteLine("This goal is already complete or did not affect your score.");
        }

        int newLevel = _levelSystem.GetLevel(_score);
        if (_levelSystem.LevelUpOccurred(_score - pts, _score))
        {
            Console.Beep();
            Console.WriteLine($"Level up! You are now level {newLevel}: {_levelSystem.GetLevelName(newLevel)}");
        }

        foreach (var badge in _badges)
        {
            if (badge.IsEarned(_score, _goals) && !badge.Announced)
            {
                badge.Announced = true;
                Console.WriteLine($"Badge earned: {badge.Name} - {badge.Description}");
            }
        }
        Console.WriteLine("Press Enter...");
        Console.ReadLine();
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetSaveString());
            }
        }
        Console.WriteLine("Saved!");
        Console.ReadLine();
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            Console.ReadLine();
            return;
        }
        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            _goals.Add(Goal.LoadFromString(lines[i]));
        }
        Console.WriteLine("Loaded!");
        Console.ReadLine();
    }
}