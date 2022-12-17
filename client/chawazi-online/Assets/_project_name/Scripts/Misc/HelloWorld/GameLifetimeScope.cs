using UnityEngine;
using VContainer;
using VContainer.Unity;


public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private InputManager inputManager;
    public DummyTouch prefab;

    protected override void Configure(IContainerBuilder builder)
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available) {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                var app = Firebase.FirebaseApp.DefaultInstance;
                Debug.Log("Elisar was here");
                // Log an event with a float parameter
                Firebase.Analytics.FirebaseAnalytics
                    .LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLevelEnd);

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            } else {
                UnityEngine.Debug.LogError(System.String.Format(
                    "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
        
        
        builder.RegisterComponent(inputManager);
        builder.Register<DefaultUnityLogger>(Lifetime.Singleton).AsImplementedInterfaces();
      //  builder.RegisterComponentInHierarchy<DummyTouch>();
       // builder.RegisterComponentInNewPrefab(prefab, Lifetime.Scoped);
    }
}