using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class InputManager : MonoBehaviour
{
    public delegate void TouchEvent(object sender, TouchEventArgs args);

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

    private void TouchOnonFingerMove(Finger obj)
    {
        OnMovingTouch?.Invoke(this, new TouchEventArgs(obj.screenPosition, (float)obj.currentTouch.time));
    }

    private void TouchOnonFingerUp(Finger obj)
    {
        OnEndTouch?.Invoke(this, new TouchEventArgs(obj.screenPosition, (float)obj.currentTouch.time));
    }

    private void TouchOnonFingerDown(Finger obj)
    {
        OnStartTouch?.Invoke(this, new TouchEventArgs(obj.screenPosition, (float)obj.currentTouch.startTime));
    }
}