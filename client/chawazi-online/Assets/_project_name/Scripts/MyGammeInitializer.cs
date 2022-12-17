using System;
using UnityEngine;

namespace _project_name.Scripts
{
    public class MyGammeInitializer : MonoBehaviour
    {
        private void Start()
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

        }
    }
}
