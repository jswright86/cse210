using System;
public abstract class Activity
{

    private DateTime _date;
    protected int _lengthInMinutes;

    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;

    }
    //GetDistance will change based on activity
    public abstract float GetDistance();
    //GetSpeed(), GetPace(), GetMinutes() stay the same no matter the activity
    public float GetSpeed()
    {
        return GetDistance() / GetMinutes() * 60;
    }
    public float GetPace()
    {
        return GetMinutes() / GetDistance();
    }
    //Changes DateTime to desired outcome
    public string FormattedDate => _date.ToString("dd MMM yyyy");
    public string GetFormattedDate()
    {
        return _date.ToString("dd MMM yyyy");
    }
    //Returns a string of all the data for the activity
    public virtual string GetSummary()
    {
        return $"{GetFormattedDate()} {GetType().Name} ({GetMinutes()}min)- Distance {GetDistance()} miles, Speed {GetSpeed()} mph, Pace: {GetPace()} per mile";
    }

    public float GetMinutes()
    {
        return _lengthInMinutes;
    }
}