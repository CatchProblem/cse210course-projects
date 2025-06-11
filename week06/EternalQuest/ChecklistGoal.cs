public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;
    private bool _completed;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus, int currentCount = 0, bool completed = false)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = currentCount;
        _completed = completed;
    }

    public override bool IsComplete() => _completed;

    public override int RecordEvent()
    {
        if (_completed) return 0;
        _currentCount++;
        int total = Points;
        if (_currentCount >= _targetCount)
        {
            _completed = true;
            total += _bonus;
        }
        return total;
    }

    public override string GetStatusString()
    {
        string status = _completed ? "[X]" : "[ ]";
        return $"{status} {Name} ({Description}) -- Completed {_currentCount}/{_targetCount} times";
    }

    public override string GetSaveString() =>
        $"ChecklistGoal|{Name}|{Description}|{Points}|{_targetCount}|{_bonus}|{_currentCount}|{_completed}";

    public static ChecklistGoal Load(string[] data)
    {
        return new ChecklistGoal(
            data[1], data[2], int.Parse(data[3]), int.Parse(data[4]),
            int.Parse(data[5]), int.Parse(data[6]), bool.Parse(data[7]));
    }
}