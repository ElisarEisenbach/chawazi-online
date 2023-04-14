using System;
using UnityEngine.InputSystem.EnhancedTouch;

public class WinnerEventArgs : EventArgs
{
    public readonly Finger winningFinger;

    public WinnerEventArgs(Finger winningFinger)
    {
        this.winningFinger = winningFinger;
    }
}