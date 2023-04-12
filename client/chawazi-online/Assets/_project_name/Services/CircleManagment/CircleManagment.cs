using System;
using UnityEngine;

[Obsolete]
public class CircleManagment : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    public int touchId;

    private void OnEnable()
    {
        inputManager = GameObject.Find("manager").GetComponent<InputManager>(); //todo: move to DI
        touchId = 0;
        inputManager.OnStartTouch += InputManager_OnStartTouch;
        inputManager.OnEndTouch += InputManager_OnEndTouch;
        inputManager.OnMovingTouch += InputManager_OnMovingTouch;
    }

    private void InputManager_OnMovingTouch(object sender, TouchEventArgs args)
    {
        if (touchId != args.Finger.currentTouch.touchId)
            return;
        //Debug.Log("Moving?");
        //GetComponent<Renderer>().enabled = true;
        var worldCoordinates = args.GetWorldCoordinates();
        transform.position = worldCoordinates;
    }

    private void InputManager_OnEndTouch(object sender, TouchEventArgs args)
    {
        if (touchId != args.Finger.currentTouch.touchId)
            return;
        GetComponent<Renderer>().enabled = false;
//        logger.Log("Ended Touch");
        Debug.Log("Ended Touch");
        GameObject.DestroyImmediate(gameObject);
        //var worldCoordinates = args.GetWorldCoordinates();
        //transform.position = worldCoordinates;
    }

    private void InputManager_OnStartTouch(object sender, TouchEventArgs args)
    {
        if (touchId == 0)
        {
            touchId = args.Finger.currentTouch.touchId;
        }

        if (touchId != args.Finger.currentTouch.touchId)
            return;

        gameObject.name = args.Finger.currentTouch.touchId.ToString();
        Debug.Log("started touch " + touchId);
        GetComponent<Renderer>().enabled = true;
        var worldCoordinates = args.GetWorldCoordinates();
        transform.position = worldCoordinates;
    }

    private void OnDestroy()
    {
        inputManager.OnStartTouch -= InputManager_OnStartTouch;
        inputManager.OnEndTouch -= InputManager_OnEndTouch;
        inputManager.OnMovingTouch -= InputManager_OnMovingTouch;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= InputManager_OnStartTouch;
        inputManager.OnEndTouch -= InputManager_OnEndTouch;
        inputManager.OnMovingTouch -= InputManager_OnMovingTouch;
    }
}