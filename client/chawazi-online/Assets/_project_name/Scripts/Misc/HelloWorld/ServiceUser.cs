using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VContainer.Unity;

public class ServiceUser : IStartable
{
    readonly HelloWorldService helloWorldService;
    readonly HelloScreen helloScreen;

    public ServiceUser(HelloWorldService helloWorldService, HelloScreen helloScreen)
    {
        this.helloWorldService = helloWorldService;
        this.helloScreen = helloScreen;
    }

    public void Start()
    {
        helloScreen.HelloButton.onClick.AddListener(() => { helloWorldService.Hello(); });
    }
}

