using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

public class DummyTouch : MonoBehaviour
{
    private InputManager inputManager;
   private ILogger logger;
    
    [Inject]
    public void Construct(ILogger logger, InputManager inputManager)
    {
        this.logger = logger;
        this.inputManager = inputManager;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += InputManager_OnStartTouch;
        inputManager.OnEndTouch += InputManager_OnEndTouch;
        inputManager.OnMovingTouch += InputManager_OnMovingTouch;
    }

    private void InputManager_OnMovingTouch(object sender, TouchEventArgs args)
    {
        logger.Log("Moving!");
        //GetComponent<Renderer>().enabled = true;
        var worldCoordinates = args.GetWorldCoordinates();
        transform.position = worldCoordinates;
    }

    private void InputManager_OnEndTouch(object sender, TouchEventArgs args)
    {
        GetComponent<Renderer>().enabled = false;
        logger.Log("Ended Touch");
        //var worldCoordinates = args.GetWorldCoordinates();
        //transform.position = worldCoordinates;
    }

    private void InputManager_OnStartTouch(object sender, TouchEventArgs args)
    {
        logger.Log("started touch");
        GetComponent<Renderer>().enabled = true;
        var worldCoordinates = args.GetWorldCoordinates();
        transform.position = worldCoordinates;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= InputManager_OnStartTouch;
        inputManager.OnEndTouch -= InputManager_OnEndTouch;
        inputManager.OnMovingTouch -= InputManager_OnMovingTouch;
    }
}
