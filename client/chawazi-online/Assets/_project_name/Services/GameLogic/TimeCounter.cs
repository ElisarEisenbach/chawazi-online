using System;
using UnityEngine;
using Zenject;

// using System.Threading;

namespace _project_name.Services.GameLogic
{
    public class TimeCounter : MonoBehaviour
    {
        public delegate void ShouldEndRound(object sender, EventArgs args);

        private int fingersCount;
        private InputManager inputManager;
        private float lastEventTime;

        private ILogger logger;


        private bool waitingForRemovingFinger;

        private void Start()
        {
            // Listen for the TouchEvent and reset the count
            inputManager.OnStartTouch += OnNeedToCancelTimer;
            //inputManager.OnMovingTouch += OnNeedToCancelTimer;
        }

        private void Update()
        {
            if (fingersCount >= 1 && !waitingForRemovingFinger)
                if (Time.time - lastEventTime > 3f)
                {
                    logger.Log("Time's up! from update!");
                    EndRound?.Invoke(this, new EventArgs());
                    waitingForRemovingFinger = true;
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
            //inputManager.OnMovingTouch -= OnNeedToCancelTimer;
            CancelTimer();
        }

        public event ShouldEndRound EndRound;

        [Inject]
        public void Constructor(InputManager inputManager, ILogger logger, FingersListScriptableObject fingerList)
        {
            fingerList.OnFingersCountChanged += FingerList_OnOnFingersCountChanged;
            this.inputManager = inputManager;
            this.logger = logger;
        }

        private void FingerList_OnOnFingersCountChanged(object sender, FingersCountChangeEventArgs fingersCountChange)
        {
            fingersCount = fingersCountChange.fingersCount;
            if (fingersCount == 0) waitingForRemovingFinger = false;
        }

        private void OnNeedToCancelTimer(object sender, TouchEventArgs args)
        {
            CancelTimer();
        }


        private void CancelTimer()
        {
            lastEventTime = Time.time;
        }
    }
}