using System;
using UnityEngine;

public class TouchEventArgs : EventArgs
{
    Vector2 position;
    float time;

    public TouchEventArgs(Vector2 position, float time)
    {
        this.position = position;
        this.time = time;
    }

    public Vector3 GetScreenCoordinates() => new Vector3(position.x, position.y, Camera.main.nearClipPlane);
    public Vector3 GetWorldCoordinates(){
        var worldCoords =
        Camera.main.ScreenToWorldPoint(GetScreenCoordinates());
        worldCoords.z = 0;
        return worldCoords;
    }
}
