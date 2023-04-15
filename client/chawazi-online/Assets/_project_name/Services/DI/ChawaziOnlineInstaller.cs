using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class ChawaziOnlineInstaller : MonoInstaller
{
    [SerializeField] private GameObject CirclePrefab;

    [SerializeField] private SettingsScriptableObject settingsScriptableObject;

    [FormerlySerializedAs("fingerListScriptabaleObject")] [FormerlySerializedAs("FingerList")] [SerializeField]
    private FingersListScriptableObject fingerListScriptableObject;


    public override void InstallBindings()
    {
        Container.Bind<ChooseWinner>().AsSingle().NonLazy();
        Container.Bind<SettingsScriptableObject>().FromInstance(settingsScriptableObject);
        Container.Bind<FingersListScriptableObject>().FromScriptableObject(fingerListScriptableObject).AsSingle();
        Container.Bind<FireBaseAnalytics>().AsSingle().NonLazy();
        Container.Bind<CircleSpawner>().AsSingle().NonLazy();
        Container.BindFactory<Circle, CircleFactory>().FromComponentInNewPrefab(CirclePrefab);
        Container.Bind<ILogger>().FromInstance(Debug.unityLogger);
    }

    private FingersListScriptableObject CreateFingerScriptableObject()
    {
        return ScriptableObject.CreateInstance<FingersListScriptableObject>();
    }
}