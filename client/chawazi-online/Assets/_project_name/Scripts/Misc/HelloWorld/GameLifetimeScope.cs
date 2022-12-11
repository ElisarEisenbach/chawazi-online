using UnityEngine;
using VContainer;
using VContainer.Unity;


public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private InputManager inputManager;
    public DummyTouch prefab;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(inputManager);
        builder.Register<DefaultUnityLogger>(Lifetime.Singleton).AsImplementedInterfaces();
        builder.RegisterComponentInHierarchy<DummyTouch>();
        builder.RegisterComponentInNewPrefab(prefab, Lifetime.Scoped);
    }
}