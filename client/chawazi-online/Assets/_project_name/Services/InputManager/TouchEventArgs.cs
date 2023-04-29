using System;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class TouchEventArgs : EventArgs
{
    private readonly Vector2 position;
    public Finger Finger;
    private float time;

    public TouchEventArgs(Finger finger)
    {
        Finger = finger;
        position = finger.screenPosition;
        time = (float)finger.currentTouch.time;
    }

    public Vector3 GetScreenCoordinates()
    {
        return new Vector3(position.x, position.y, Camera.main.nearClipPlane);
    }

    public Vector3 GetWorldCoordinates()
    {
        var worldCoords =
            Camera.main.ScreenToWorldPoint(GetScreenCoordinates());
        worldCoords.z = 0;
        return worldCoords;
    }
}