using System;
using System.Collections.Generic;
using System.Linq;
using _project_name.Services.GameLogic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Random = System.Random;

namespace _project_name.Services.CircleManagment
{
    public class ChooseWinner
    {
        public delegate void WinnerChoosen(object sender, EventArgs args);

        // think: move list to scriptableObject that can be trace from other places too
        private readonly List<Finger> playingFingers = new();

        private InputManager inputManager;

        public ChooseWinner(InputManager inputManager, TimeCounter timeCounter)
        {
            Debug.Log("Initialized");
            timeCounter.EndRound += OnRoundEnded;
            inputManager.OnStartTouch += (sender, args) => { playingFingers.Add(args.Finger); };
            inputManager.OnEndTouch += (sender, args) =>
            {
                var fingerToRemove = playingFingers.FirstOrDefault(f => f.index == args.Finger.index);
                if (fingerToRemove != null) playingFingers.Remove(fingerToRemove);
            };
        }

        private void OnRoundEnded(object sender, EventArgs args)
        {
            var choosenPlayer = ChooseRandomWinner();
            WinnerHasBeenChoosen?.Invoke(this, new WinnerEventArgs(choosenPlayer));
        }

        public event WinnerChoosen WinnerHasBeenChoosen;

        private Finger ChooseRandomWinner()
        {
            var random = new Random();
            var randomIndex = random.Next(playingFingers.Count);
            return playingFingers[randomIndex];
        }
    }
}