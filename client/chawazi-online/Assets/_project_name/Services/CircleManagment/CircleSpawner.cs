using UnityEngine;

public class CircleSpawner
{
    private readonly CircleFactory circleFactory;
    private readonly ILogger logger;

    public CircleSpawner(CircleFactory circleFactory, InputManager inputManager, ILogger logger)
    {
        this.circleFactory = circleFactory;
        inputManager.OnStartTouch += CreateCircle;
        this.logger = logger;
        logger.Log("here??");
    }

    private void CreateCircle(object sender, TouchEventArgs args)
    {
        logger.Log("hey!");
        var circle = circleFactory.Create();
        if (circle.touchId == 0) circle.touchId = args.Finger.currentTouch.touchId;
        if (circle.touchId != args.Finger.currentTouch.touchId)
            return;

        circle.name = args.Finger.currentTouch.touchId.ToString();
        //logger.Log("started touch " + touchId);
        circle.GetComponent<Renderer>().enabled = true;
        var worldCoordinates = args.GetWorldCoordinates();
        circle.transform.position = worldCoordinates;
    }
}