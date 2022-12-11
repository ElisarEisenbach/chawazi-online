using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DummyTouch : MonoBehaviour
{

    [SerializeField] private InputManager InputManager;

    private void OnEnable()
    {
        InputManager.OnStartTouch += InputManager_OnStartTouch;
        InputManager.OnEndTouch += InputManager_OnEndTouch;
        InputManager.OnMovingTouch += InputManager_OnMovingTouch;
    }

    private void InputManager_OnMovingTouch(object sender, TouchEventArgs args)
    {
        Debug.Log("Moving!");
        //GetComponent<Renderer>().enabled = true;
        var worldCoordinates = args.GetWorldCoordinates();
        transform.position = worldCoordinates;
    }

    private void InputManager_OnEndTouch(object sender, TouchEventArgs args)
    {
        GetComponent<Renderer>().enabled = false;
        Debug.Log("End Touch");
        //var worldCoordinates = args.GetWorldCoordinates();
        //transform.position = worldCoordinates;
    }

    private void InputManager_OnStartTouch(object sender, TouchEventArgs args)
    {
        Debug.Log("started touch");
        GetComponent<Renderer>().enabled = true;
        var worldCoordinates = args.GetWorldCoordinates();
        transform.position = worldCoordinates;
    }

    private void OnDisable()
    {
        InputManager.OnStartTouch -= InputManager_OnStartTouch;
        InputManager.OnEndTouch -= InputManager_OnEndTouch;
    }
}
