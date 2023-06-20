using UnityEngine;
using Zenject;

public class OpenSceneInstaller : MonoInstaller
{
    [SerializeField] private SettingsScriptableObject settingsScriptableObject;
    [SerializeField] private GameObject CirclePrefab;

    public override void InstallBindings()
    {
        Container.Bind<SettingsScriptableObject>().FromInstance(settingsScriptableObject);
        Container.Bind<ILogger>().FromInstance(Debug.unityLogger);
        Container.Bind<RandomCircle>().FromComponentInNewPrefab(CirclePrefab).AsSingle();
    }
}