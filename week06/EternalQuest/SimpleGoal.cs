public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points, bool completed = false)
        : base(name, description, points)
    {
        _completed = completed;
    }

    public override bool IsComplete() => _completed;

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return Points;
        }
        return 0;
    }

    public override string GetStatusString() =>
        $"[{"X",1}] {Name} ({Description})";

    public override string GetSaveString() =>
        $"SimpleGoal|{Name}|{Description}|{Points}|{_completed}";

    public static SimpleGoal Load(string[] data)
    {
        return new SimpleGoal(
            data[1], data[2], int.Parse(data[3]), bool.Parse(data[4]));
    }
}