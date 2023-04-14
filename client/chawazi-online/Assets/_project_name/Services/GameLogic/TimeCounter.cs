using System;
using System.Threading;
using UnityEngine;
using Zenject;

namespace _project_name.Services.GameLogic
{
    public class TimeCounter : MonoBehaviour
    {
        public delegate void ShouldEndRound(object sender, EventArgs args);


        private int count;

        private CancellationTokenSource cts;

        private InputManager inputManager;

        private ILogger logger;

        private void Start()
        {
            cts = new CancellationTokenSource();
            count = 0;

            // Start the countdown loop on a separate thread
            ThreadPool.QueueUserWorkItem(state =>
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    logger.Log("Count: " + count);
                    count++;
                    Thread.Sleep(1000);
                    if (count == 10)
                    {
                        logger.Log("Time's up!");
                        CancelTimer();
                        EndRound?.Invoke(this, new EventArgs());
                    }
                }
            });

            // Listen for the TouchEvent and reset the count
            inputManager.OnStartTouch += HandleTouchEvent;
            inputManager.OnMovingTouch += HandleTouchEvent;
        }

        private void OnDestroy()
        {
            // Unsubscribe from the TouchEvent
            inputManager.OnStartTouch -= HandleTouchEvent;
            inputManager.OnMovingTouch -= HandleTouchEvent;
        }

        public event ShouldEndRound EndRound;

        [Inject]
        public void Constructor(InputManager inputManager, ILogger logger)
        {
            this.inputManager = inputManager;
            this.logger = logger;
        }

        private void HandleTouchEvent(object sender, TouchEventArgs args)
        {
            CancelTimer();
        }

        private void CancelTimer()
        {
            cts.Cancel();
            cts = new CancellationTokenSource();
            count = 0;
        }
    }
}