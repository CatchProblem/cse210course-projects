using System;

public abstract class Activity
{
    private DateTime _date;
    private double _lengthMinutes;

    public Activity(DateTime date, double lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public DateTime Date => _date;
    public double LengthMinutes => _lengthMinutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        // Format date
        string dateStr = _date.ToString("dd MMM yyyy");

        // Get activity type name (Running, Cycling, Swimming)
        string activityType = this.GetType().Name;

        // Length minutes formatted
        string lengthStr = $"{_lengthMinutes} min";

        // Compose summary
        return $"{dateStr} {activityType} ({lengthStr}): Distance {GetDistance():0.0} miles, " +
            $"Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.00} min per mile";
    }
}
