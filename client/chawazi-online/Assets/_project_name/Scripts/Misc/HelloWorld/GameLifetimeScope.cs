using UnityEngine;
using VContainer;
using VContainer.Unity;


public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private HelloScreen helloScreen;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<HelloWorldService>(Lifetime.Singleton);
        builder.Register<DefaultUnityLogger>(Lifetime.Singleton).AsImplementedInterfaces();
        builder.RegisterEntryPoint<ServiceUser>();
        builder.RegisterComponent(helloScreen);
    }
}
