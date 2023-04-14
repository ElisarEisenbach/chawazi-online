using System;
using System.Collections.Generic;
using _project_name.Services.GameLogic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Random = System.Random;

public class ChooseWinner
{
    public delegate void WinnerChoosen(object sender, WinnerEventArgs args);

    private readonly FingersListScriptableObject fingersListScriptableObject;

    private readonly ILogger logger;

    // think: move list to scriptableObject that can be trace from other places too
    // ya, i should
    //private readonly List<Finger> playingFingers = new();


    public ChooseWinner(InputManager inputManager, TimeCounter timeCounter, ILogger logger,
        FingersListScriptableObject fingersListScriptableObject)
    {
        this.logger = logger;
        this.fingersListScriptableObject = fingersListScriptableObject;
        Debug.Log("Initialized????????");
        timeCounter.EndRound += OnRoundEnded;
        // inputManager.OnStartTouch += (sender, args) => { playingFingers.Add(args.Finger); };
        // inputManager.OnEndTouch += (sender, args) =>
        // {
        //     var fingerToRemove =
        //         playingFingers.FirstOrDefault(f => f.currentTouch.touchId == args.Finger.currentTouch.touchId);
        //     if (fingerToRemove != null) playingFingers.Remove(fingerToRemove);
        // };
    }

    private void OnRoundEnded(object sender, EventArgs args)
    {
        logger.Log(fingersListScriptableObject.PlayingFingers.Count + "ok so far works");
        var choosenPlayer = ChooseRandomWinner(fingersListScriptableObject.PlayingFingers);
        logger.Log("winning player is: " + choosenPlayer.index);
        WinnerHasBeenChoosen?.Invoke(this, new WinnerEventArgs(choosenPlayer));
    }

    public event WinnerChoosen WinnerHasBeenChoosen;

    private Finger ChooseRandomWinner(List<Finger> playingFingers)
    {
        var random = new Random();
        var randomIndex = random.Next(playingFingers.Count);
        return playingFingers[randomIndex];
    }
}