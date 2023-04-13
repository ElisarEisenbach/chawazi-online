using _project_name.Services.CircleManagment;
using UnityEngine;
using Zenject;

public class ChawaziOnlineInstaller : MonoInstaller
{
    public GameObject CirclePrefab;
    public AnalyticsScriptableObject AnalyticsScriptableObject;


    public override void InstallBindings()
    {
        Container.Bind<AnalyticsScriptableObject>().FromInstance(AnalyticsScriptableObject);
        Container.Bind<FireBaseAnalytics>().AsSingle().NonLazy();
        Container.Bind<CircleSpawner>().AsSingle().NonLazy();
        Container.BindFactory<Circle, CircleFactory>().FromComponentInNewPrefab(CirclePrefab);
        Container.Bind<ILogger>().FromInstance(Debug.unityLogger);
        Container.Bind<ChooseWinner>().AsSingle().NonLazy();
    }
}