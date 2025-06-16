using System;

public class Cycling : Activity
{
    private double _speedMph;

    public Cycling(DateTime date, double lengthMinutes, double speedMph) 
        : base(date, lengthMinutes)
    {
        _speedMph = speedMph;
    }

    public override double GetDistance()
    {
        // distance = speed * time (hours)
        return _speedMph * (LengthMinutes / 60);
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetPace()
    {
        // Pace = 60 / speed (minutes per mile)
        return 60 / _speedMph;
    }
}
