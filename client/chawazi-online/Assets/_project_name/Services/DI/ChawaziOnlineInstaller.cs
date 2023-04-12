using UnityEngine;
using Zenject;

public class ChawaziOnlineInstaller : MonoInstaller
{
    public GameObject CirclePrefab;


    public override void InstallBindings()
    {
        Container.Bind<CircleSpawner>().AsSingle().NonLazy();
        Container.BindFactory<Circle, CircleFactory>().FromComponentInNewPrefab(CirclePrefab);
        Container.Bind<ILogger>().FromInstance(Debug.unityLogger);
    }
}