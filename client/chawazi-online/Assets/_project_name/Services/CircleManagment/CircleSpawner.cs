using UnityEngine;

public class CircleSpawner
{
    private readonly CircleFactory circleFactory;

    private readonly ILogger logger;
    //private readonly GameObject gamePanel;

    public CircleSpawner(CircleFactory circleFactory, InputManager inputManager, ILogger logger)
    {
        this.circleFactory = circleFactory;
        inputManager.OnStartTouch += CreateCircle;
        this.logger = logger;
        //this.gamePanel = gamePanel;
    }

    private void CreateCircle(object sender, TouchEventArgs args)
    {
        var circle = circleFactory.Create();
        if (circle.touchId == 0)
            circle.touchId = args.Finger.currentTouch.touchId;
        //circle.gameObject.transform.parent = gamePanel.transform;

        if (circle.touchId != args.Finger.currentTouch.touchId)
            return;

        circle.name = args.Finger.currentTouch.touchId.ToString();
        //logger.Log("started touch " + touchId);
        circle.GetComponent<Renderer>().enabled = true;
        var worldCoordinates = args.GetWorldCoordinates();
        circle.transform.position = worldCoordinates;
    }
}