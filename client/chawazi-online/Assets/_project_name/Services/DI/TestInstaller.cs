using Zenject;
using UnityEngine;
using System.Collections;

public class TestInstaller : MonoInstaller<TestInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<ILogger>().To<DefaultUnityLogger>().AsSingle();
    }
}
