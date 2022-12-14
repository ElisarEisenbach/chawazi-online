using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Zenject;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;


public delegate void TouchEvent(object sender, TouchEventArgs args);


public class InputManager : MonoBehaviour
{
    private ILogger logger;

    [Inject]
    public void Constructor(ILogger logger)
    {
        this.logger = logger;
    }
    
    public GameObject cube; //todo:
    
    public event TouchEvent OnStartTouch;
    public event TouchEvent OnEndTouch;
    public event TouchEvent OnMovingTouch;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    private void Start()
    {
        Touch.onFingerDown += TouchOnonFingerDown;
        Touch.onFingerMove += TouchOnonFingerMove;
        Touch.onFingerUp += TouchOnonFingerUp;
    }

    private void TouchOnonFingerMove(Finger finger)
    {
        OnMovingTouch?.Invoke(this, new TouchEventArgs(finger));
    }

    private void TouchOnonFingerUp(Finger finger)
    {
        OnEndTouch?.Invoke(this, new TouchEventArgs(finger));
    }

    private void TouchOnonFingerDown(Finger finger)
    {
        Instantiate(cube);//factory
        OnStartTouch?.Invoke(this, new TouchEventArgs(finger));
        logger.Log("DI is working");
    }
}