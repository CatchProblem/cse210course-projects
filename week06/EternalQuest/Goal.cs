using System;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public string Name { get => _name; protected set => _name = value; }
    public string Description { get => _description; protected set => _description = value; }
    public int Points { get => _points; protected set => _points = value; }

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract bool IsComplete();
    public abstract int RecordEvent();
    public abstract string GetStatusString();
    public abstract string GetSaveString();

    // Factory method for loading from file
    public static Goal LoadFromString(string data)
    {
        string[] parts = data.Split('|');
        switch (parts[0])
        {
            case "SimpleGoal":
                return SimpleGoal.Load(parts);
            case "EternalGoal":
                return EternalGoal.Load(parts);
            case "ChecklistGoal":
                return ChecklistGoal.Load(parts);
            case "NegativeGoal":
                return NegativeGoal.Load(parts);
            default:
                throw new Exception("Unknown goal type");
        }
    }
}