using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Zenject;

[CreateAssetMenu(fileName = "FingersList", menuName = "GameLogics", order = 0)]
public class FingersListScriptableObject : ScriptableObject
{
    public List<int> Ids = new();
    public List<Finger> PlayingFingers = new();

    [Inject]
    private void Construct(InputManager inputManager)
    {
        inputManager.OnStartTouch += (sender, args) =>
        {
            PlayingFingers.Add(args.Finger);
            Ids.Add(args.Finger.currentTouch.touchId);
            getIds();
        };
        inputManager.OnEndTouch += (sender, args) =>
        {
            var fingerToRemove =
                PlayingFingers.FirstOrDefault(f => f.currentTouch.touchId == args.Finger.currentTouch.touchId);
            if (fingerToRemove != null) PlayingFingers.Remove(fingerToRemove);

            var idsToRemove =
                Ids.FirstOrDefault(f => f == args.Finger.currentTouch.touchId);
            if (idsToRemove != null) Ids.Remove(idsToRemove);
        };
    }

    private void getIds()
    {
        foreach (var id in Ids) Debug.Log("id " + id);
    }
}