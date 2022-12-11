using UnityEngine;
using VContainer;
using VContainer.Unity;


public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private InputManager inputManager;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(inputManager);
        builder.RegisterComponentInHierarchy<DummyTouch>();
        builder.Register<DefaultUnityLogger>(Lifetime.Singleton).AsImplementedInterfaces();
    }
}