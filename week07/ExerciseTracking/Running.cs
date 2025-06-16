using System;

public class Running : Activity
{
    private double _distanceMiles;

    public Running(DateTime date, double lengthMinutes, double distanceMiles) 
        : base(date, lengthMinutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        // Speed in miles per hour
        return (GetDistance() / LengthMinutes) * 60;
    }

    public override double GetPace()
    {
        // Pace in minutes per mile
        return LengthMinutes / GetDistance();
    }
}
