using System;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

public class Circle : MonoBehaviour
    {
        public int touchId;
        [SerializeField] private InputManager inputManager;

        
        [Inject]
        public void Construct(InputManager inputManager)
        {
            this.inputManager = inputManager;
        }
        
        private void OnEnable()
        {
            inputManager.OnEndTouch += InputManager_OnEndTouch;
            inputManager.OnMovingTouch += InputManager_OnMovingTouch;
        }

        private void OnDisable()
        {
            inputManager.OnEndTouch -= InputManager_OnEndTouch;
            inputManager.OnMovingTouch -= InputManager_OnMovingTouch;
        }

        private void OnDestroy()
        {
            inputManager.OnEndTouch -= InputManager_OnEndTouch;
            inputManager.OnMovingTouch -= InputManager_OnMovingTouch;
        }


        private void InputManager_OnMovingTouch(object sender, TouchEventArgs args)
        {
            if (touchId != args.Finger.currentTouch.touchId)
                return;
            //Debug.Log("Moving?");
            //GetComponent<Renderer>().enabled = true;
            var worldCoordinates = args.GetWorldCoordinates();
            transform.position = worldCoordinates;
        }

        private void InputManager_OnEndTouch(object sender, TouchEventArgs args)
        {
            if (touchId != args.Finger.currentTouch.touchId)
                return;
            GetComponent<Renderer>().enabled = false;
//        logger.Log("Ended Touch");
            Debug.Log("Ended Touch");
            DestroyImmediate(gameObject);
        }
        
    }
