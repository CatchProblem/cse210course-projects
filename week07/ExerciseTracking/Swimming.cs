using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, double lengthMinutes, int laps) 
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Distance in miles: laps * 50 meters per lap / 1000 * 0.62 miles per km
        return _laps * 50 / 1000.0 * 0.62;
    }

    public override double GetSpeed()
    {
        // Speed in mph
        return (GetDistance() / LengthMinutes) * 60;
    }

    public override double GetPace()
    {
        return LengthMinutes / GetDistance();
    }
}
