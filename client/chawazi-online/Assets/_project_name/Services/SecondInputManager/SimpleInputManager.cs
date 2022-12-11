using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleInputManager : MonoBehaviour
{
    void FixedUpdate()
    {
        var touchscreen = Touchscreen.current;
       
        if (touchscreen == null)
            return; // No gamepad connected.

        if (touchscreen.primaryTouch.press.isPressed)
        {
            Debug.Log("pressed");
            //Debug.Log(touchscreen.primaryTouch.position.x.ReadValue());
           var worldcoord =  Camera.main.ScreenToWorldPoint(new Vector3(touchscreen.primaryTouch.position.x.ReadValue(),
                touchscreen.primaryTouch.position.y.ReadValue(), Camera.main.nearClipPlane));
           worldcoord.z = 0;

           transform.position = worldcoord;
        }

        var move = touchscreen.primaryTouch.position;
        // 'Move' code here
      
    }
}