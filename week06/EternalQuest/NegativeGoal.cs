// CREATIVITY: Negative goal type (lose points for bad habits)
public class NegativeGoal : Goal
{
    private int _failures;

    public NegativeGoal(string name, string description, int points, int failures = 0)
        : base(name, description, points)
    {
        _failures = failures;
    }

    public override bool IsComplete() => false;

    public override int RecordEvent()
    {
        _failures++;
        return -Points;
    }

    public override string GetStatusString() =>
        $"[!] {Name} ({Description}) -- Recorded {_failures} times (Lose {Points} each)";

    public override string GetSaveString() =>
        $"NegativeGoal|{Name}|{Description}|{Points}|{_failures}";

    public static NegativeGoal Load(string[] data)
    {
        return new NegativeGoal(
            data[1], data[2], int.Parse(data[3]), int.Parse(data[4]));
    }
}