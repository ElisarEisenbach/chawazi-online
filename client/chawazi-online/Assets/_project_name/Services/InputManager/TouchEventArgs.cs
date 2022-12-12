using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class TouchEventArgs : EventArgs
{
    public Finger Finger;
    
    Vector2 position;
    float time;

    public TouchEventArgs(Finger finger)
    {
        this.Finger = finger;
        this.position = finger.screenPosition;
        this.time = (float)finger.currentTouch.time;
    }

    public Vector3 GetScreenCoordinates() => new Vector3(position.x, position.y, Camera.main.nearClipPlane);
    public Vector3 GetWorldCoordinates(){
        var worldCoords =
        Camera.main.ScreenToWorldPoint(GetScreenCoordinates());
        worldCoords.z = 0;
        return worldCoords;
    }
}
