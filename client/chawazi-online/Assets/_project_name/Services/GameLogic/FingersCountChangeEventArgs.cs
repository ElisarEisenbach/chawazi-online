using System;

public class FingersCountChangeEventArgs : EventArgs
{
    public enum ChangeType
    {
        Added,
        Removed
    }

    public readonly int fingersCount;
    public readonly int id;
    public ChangeType CurrentFingerChangeType;

    public FingersCountChangeEventArgs(int fingersCount, int id, ChangeType changeType)
    {
        CurrentFingerChangeType = changeType;
        this.fingersCount = fingersCount;
        this.id = id;
    }
}