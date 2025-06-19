using System;

class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;
    private const double MeterToMiles = 0.000621371;

    public Swimming(DateTime date, int lengthMinutes, int laps) : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * LapLengthMeters * MeterToMiles;

    public override double GetSpeed() => (GetDistance() / LengthMinutes) * 60;

    public override double GetPace() => LengthMinutes / GetDistance();
}
