public class EternalGoal : Goal
{
    private int _completions;

    public EternalGoal(string name, string description, int points, int completions = 0)
        : base(name, description, points)
    {
        _completions = completions;
    }

    public override bool IsComplete() => false;

    public override int RecordEvent()
    {
        _completions++;
        return Points;
    }

    public override string GetStatusString() =>
        $"[∞] {Name} ({Description}) -- Completed {_completions} times";

    public override string GetSaveString() =>
        $"EternalGoal|{Name}|{Description}|{Points}|{_completions}";

    public static EternalGoal Load(string[] data)
    {
        return new EternalGoal(
            data[1], data[2], int.Parse(data[3]), int.Parse(data[4]));
    }
}