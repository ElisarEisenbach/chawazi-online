using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Zenject;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public delegate void TouchEvent(object sender, TouchEventArgs args);

//todo create interface
public class InputManager : MonoBehaviour
{
    public GameObject cube; //todo:
    private ILogger logger;

    private void Start()
    {
        Touch.onFingerDown += TouchOnFingerDown;
        Touch.onFingerMove += TouchOnFingerMove;
        Touch.onFingerUp += TouchOnFingerUp;
    }

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
        Touch.onFingerDown -= TouchOnFingerDown;
        Touch.onFingerMove -= TouchOnFingerMove;
        Touch.onFingerUp -= TouchOnFingerUp;
    }

    [Inject]
    public void Constructor(ILogger logger)
    {
        this.logger = logger;
    }

    public event TouchEvent OnStartTouch;
    public event TouchEvent OnEndTouch;
    public event TouchEvent OnMovingTouch;

    private void TouchOnFingerMove(Finger finger)
    {
        OnMovingTouch?.Invoke(this, new TouchEventArgs(finger));
    }

    private void TouchOnFingerUp(Finger finger)
    {
        OnEndTouch?.Invoke(this, new TouchEventArgs(finger));
    }

    private void TouchOnFingerDown(Finger finger)
    {
        //Instantiate(cube);//factory
        OnStartTouch?.Invoke(this, new TouchEventArgs(finger));
        logger.Log("DI is working");
    }
}