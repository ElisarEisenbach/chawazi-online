using UnityEngine;
using Zenject;

public class Circle : MonoBehaviour
{
    public int touchId;
    private ChooseWinner chooseWinner;
    private InputManager inputManager;
    private ILogger logger;

    private void OnEnable()
    {
        inputManager.OnEndTouch += InputManager_OnEndTouch;
        inputManager.OnMovingTouch += InputManager_OnMovingTouch;
        chooseWinner.WinnerHasBeenChoosen += ChooseWinner_OnWinnerHasBeenChoosen;
    }

    private void OnDisable()
    {
        inputManager.OnEndTouch -= InputManager_OnEndTouch;
        inputManager.OnMovingTouch -= InputManager_OnMovingTouch;
        chooseWinner.WinnerHasBeenChoosen -= ChooseWinner_OnWinnerHasBeenChoosen;
    }

    private void OnDestroy()
    {
        inputManager.OnEndTouch -= InputManager_OnEndTouch;
        inputManager.OnMovingTouch -= InputManager_OnMovingTouch;
        chooseWinner.WinnerHasBeenChoosen -= ChooseWinner_OnWinnerHasBeenChoosen;
    }

    private void ChooseWinner_OnWinnerHasBeenChoosen(object sender, WinnerEventArgs args)
    {
        var animator = gameObject.GetComponent<Animator>();
        // todo: add animations
        if (touchId != args.winningFinger.currentTouch.touchId)
        {
            animator.SetBool("IsLooser", true);
        }
        else
        {
            animator.SetBool("IsWinner", true);
            logger.Log("Winner!");
        }
    }

    public void OnAnimationEnd()
    {
        this.DestroyCircle();
    }


    [Inject]
    public void Construct(InputManager inputManager, ChooseWinner chooseWinner, ILogger logger)
    {
        this.logger = logger;
        this.inputManager = inputManager;
        this.chooseWinner = chooseWinner;
    }


    private void InputManager_OnMovingTouch(object sender, TouchEventArgs args)
    {
        if (touchId != args.Finger.currentTouch.touchId)
            return;
        var worldCoordinates = args.GetWorldCoordinates();
        transform.position = worldCoordinates;
    }

    private void InputManager_OnEndTouch(object sender, TouchEventArgs args)
    {
        if (touchId != args.Finger.currentTouch.touchId)
            return;
        GetComponent<Renderer>().enabled = false;
        Debug.Log("Ended Touch");
        DestroyImmediate(gameObject);
    }
}