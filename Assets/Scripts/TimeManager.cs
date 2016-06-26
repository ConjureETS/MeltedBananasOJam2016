using System;

public static class TimeManager
{
    private static float slowFactor;
    public static float SlowFactor
    {
        get
        {
            return slowFactor;
        }
        set
        {
            slowFactor = value;
        }
    }
}

