using UnityEngine;
using VContainer;

public class HelloWorldService
{
    private readonly ILogger logger;

    public HelloWorldService(ILogger logger)
    {
        this.logger = logger;
    }

    public void Hello()
    {
        logger.Log("Hello world");
    }
}
