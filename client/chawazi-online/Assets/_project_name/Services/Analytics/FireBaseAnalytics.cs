using Firebase;
using UnityEngine;

public class FireBaseAnalytics : IAnalytics
{
    private readonly ILogger logger;

    public FireBaseAnalytics(ILogger logger, AnalyticsScriptableObject analyticsScriptableObject)
    {
        this.logger = logger;
        if (analyticsScriptableObject.isEnabled) InitializeAnalytics();
    }


    public void InitializeAnalytics()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                var app = FirebaseApp.DefaultInstance;
                logger.Log("firebase analytics");
                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                logger.Log(string.Format(
                    "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }
}