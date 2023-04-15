using System;
using UnityEngine;
using Zenject;

// using System.Threading;

namespace _project_name.Services.GameLogic
{
    public class TimeCounter : MonoBehaviour
    {
        public delegate void ShouldEndRound(object sender, EventArgs args);


        private int count;

        //  private CancellationTokenSource cts;
        private FingersListScriptableObject fingerList;

        private InputManager inputManager;
        private float lastEventTime;

        private ILogger logger;

        private bool shouldCount;

        private void Start()
        {
            //   cts = new CancellationTokenSource();
            count = 0;

            // // Start the countdown loop on a separate thread
            // ThreadPool.QueueUserWorkItem(state =>
            // {
            //     while (!cts.Token.IsCancellationRequested)
            //     {
            //         count++;
            //         Thread.Sleep(1000);
            //         if (count == 3)
            //         {
            //             logger.Log("Time's up!");
            //             EndRound?.Invoke(this, new EventArgs());
            //             CancelTimer();
            //         }
            //     }
            // });

            // Listen for the TouchEvent and reset the count
            inputManager.OnStartTouch += OnNeedToCancelTimer;
            inputManager.OnMovingTouch += OnNeedToCancelTimer;
        }

        private void Update()
        {
            if (fingerList.PlayingFingers.Count >= 1)
                if (Time.time - lastEventTime > 3f)
                {
                    logger.Log("Time's up! from update!");
                    EndRound?.Invoke(this, new EventArgs());
                    CancelTimer();
                }
        }

        private void OnDisable()
        {
            CancelTimer();
        }

        private void OnDestroy()
        {
            // Unsubscribe from the TouchEvent
            inputManager.OnStartTouch -= OnNeedToCancelTimer;
            inputManager.OnMovingTouch -= OnNeedToCancelTimer;
            CancelTimer();
        }

        public event ShouldEndRound EndRound;

        [Inject]
        public void Constructor(InputManager inputManager, ILogger logger, FingersListScriptableObject fingerList)
        {
            this.fingerList = fingerList;
            this.inputManager = inputManager;
            this.logger = logger;
        }

        private void OnNeedToCancelTimer(object sender, TouchEventArgs args)
        {
            CancelTimer();
        }

        private void OnNeedToStartTimer(object sender, TouchEventArgs args)
        {
            shouldCount = true;
        }

        private void CancelTimer()
        {
            lastEventTime = Time.time;

            //  cts.Cancel();
            //  cts = new CancellationTokenSource();
            count = 0;
        }
    }
}