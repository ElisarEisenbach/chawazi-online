using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public delegate void TouchEvent(object sender, TouchEventArgs args);
    public event TouchEvent OnStartTouch;
    public event TouchEvent OnEndTouch;


    private TouchControls touchControls;

    private void Awake()
    {
        touchControls = new TouchControls();
    }
    private void OnEnable()
    {
        touchControls.Enable();
    }
    private void OnDisable()
    {
        touchControls.Disable();
    }
    private void Start()
    {
        touchControls.touch.TouchPress.started += obj => { Debug.Log("job Started " + touchControls.touch.TouchPosition.ReadValue<Vector2>());
            OnStartTouch?.Invoke(this,new TouchEventArgs(touchControls.touch.TouchPosition.ReadValue<Vector2>(), (float)obj.startTime));
        };
        touchControls.touch.TouchPress.canceled += obj => { Debug.Log("job canceled " + touchControls.touch.TouchPosition.ReadValue<Vector2>());
            OnEndTouch?.Invoke(this, new TouchEventArgs(touchControls.touch.TouchPosition.ReadValue<Vector2>(), (float)obj.startTime));
            var timeTouched = obj.time - obj.startTime;
        };
    }


}
