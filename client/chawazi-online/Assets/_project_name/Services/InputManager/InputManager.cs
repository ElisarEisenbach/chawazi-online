using UnityEditor;
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
        Touch.onFingerDown -= TouchOnFingerDown;
        Touch.onFingerMove -= TouchOnFingerMove;
        Touch.onFingerUp -= TouchOnFingerUp;
        EnhancedTouchSupport.Disable();
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
#if UNITY_EDITOR
        if (!EditorApplication.isPaused) OnMovingTouch?.Invoke(this, new TouchEventArgs(finger));
#else
        OnMovingTouch?.Invoke(this, new TouchEventArgs(finger));
#endif
    }

    private void TouchOnFingerUp(Finger finger)
    {
#if UNITY_EDITOR
        if (!EditorApplication.isPaused) OnEndTouch?.Invoke(this, new TouchEventArgs(finger));
#else
        OnEndTouch?.Invoke(this, new TouchEventArgs(finger));
#endif
    }

    private void TouchOnFingerDown(Finger finger)
    {
#if UNITY_EDITOR
        if (!EditorApplication.isPaused) OnStartTouch?.Invoke(this, new TouchEventArgs(finger));
#else
        OnStartTouch?.Invoke(this, new TouchEventArgs(finger));
#endif
    }
}