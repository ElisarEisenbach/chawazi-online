using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Zenject;

[CreateAssetMenu(fileName = "FingersList", menuName = "GameLogics", order = 0)]
public class FingersListScriptableObject : ScriptableObject
{
    public List<Finger> PlayingFingers = new();
    public event Action<object, FingersCountChangeEventArgs> OnFingersCountChanged;

    [Inject]
    private void Construct(InputManager inputManager)
    {
        inputManager.OnStartTouch += InputManager_OnOnStartTouch;
        inputManager.OnEndTouch += InputManager_OnOnEndTouch;
    }

    private void InputManager_OnOnEndTouch(object sender, TouchEventArgs args)
    {
        var fingerToRemove =
            PlayingFingers.FirstOrDefault(f => f.currentTouch.touchId == args.Finger.currentTouch.touchId);
        if (fingerToRemove != null) PlayingFingers.Remove(fingerToRemove);
        OnFingersCountChanged?.Invoke(this,
            new FingersCountChangeEventArgs(PlayingFingers.Count, args.Finger.currentTouch.touchId,
                FingersCountChangeEventArgs.ChangeType.Removed));
    }

    private void InputManager_OnOnStartTouch(object sender, TouchEventArgs args)
    {
        PlayingFingers.Add(args.Finger);
        OnFingersCountChanged?.Invoke(this,
            new FingersCountChangeEventArgs(PlayingFingers.Count, args.Finger.currentTouch.touchId,
                FingersCountChangeEventArgs.ChangeType.Added));
    }
}

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