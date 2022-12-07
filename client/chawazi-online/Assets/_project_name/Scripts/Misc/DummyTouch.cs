using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTouch : MonoBehaviour
{

    [SerializeField] private InputManager InputManager;

    private void OnEnable()
    {
        InputManager.OnStartTouch += InputManager_OnStartTouch;
    }

    private void InputManager_OnStartTouch(object sender, TouchEventArgs args)
    {
        var worldCoordinates = args.GetWorldCoordinates();
        transform.position = worldCoordinates;
    }

    private void OnDisable()
    {
        InputManager.OnStartTouch -= InputManager_OnStartTouch;
    }






    // Update is called once per frame
    void Update()
    {

    }
}
