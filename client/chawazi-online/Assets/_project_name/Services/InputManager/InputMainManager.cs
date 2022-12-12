using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class InputMainManager : MonoBehaviour
{

    public event TouchEvent NewTouchStarted;
    public event TouchEvent TouchFinished;
    
    
    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Touch.onFingerDown += finger => Debug.Log(finger.index + " new finger");
        Touch.onFingerUp += finger => Debug.Log(finger.index + " end finger");
    }

}
