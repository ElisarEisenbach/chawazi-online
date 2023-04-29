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
        CircleDestroyerHelper.OnDestroyCircle += CircleDestroyerHelper_OnOnDestroyCircle;
    }

    private void CircleDestroyerHelper_OnOnDestroyCircle(Circle destroyedCircle)
    {
        var fingerIdToRemove = destroyedCircle.touchId;
        RemoveFinger(fingerIdToRemove);
    }

    private void InputManager_OnOnEndTouch(object sender, TouchEventArgs args)
    {
        var fingerIdToRemove = args.Finger.currentTouch.touchId;
        RemoveFinger(fingerIdToRemove);
    }

    private void InputManager_OnOnStartTouch(object sender, TouchEventArgs args)
    {
        PlayingFingers.Add(args.Finger);
        OnFingersCountChanged?.Invoke(this,
            new FingersCountChangeEventArgs(PlayingFingers.Count, args.Finger.currentTouch.touchId,
                FingersCountChangeEventArgs.ChangeType.Added));
    }


    private void RemoveFinger(int id)
    {
        var fingerToRemove = PlayingFingers.FirstOrDefault(f => f.currentTouch.touchId == id);
        if (fingerToRemove != null)
        {
            PlayingFingers.Remove(fingerToRemove);
            OnFingersCountChanged?.Invoke(this,
                new FingersCountChangeEventArgs(PlayingFingers.Count, id,
                    FingersCountChangeEventArgs.ChangeType.Removed));
        }
    }
}