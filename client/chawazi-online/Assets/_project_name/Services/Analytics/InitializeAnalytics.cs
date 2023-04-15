using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _project_name.Services.Analytics
{
    public class InitializeAnalytics : MonoBehaviour
    {
        private readonly List<IAnalytics> analytics = new();
        private bool initialize;
        private ILogger logger;

        private void Start()
        {
            analytics.Add(new FireBaseAnalytics(logger));
            if (initialize && analytics.Count > 0)
                foreach (var analytic in analytics)
                    analytic.InitializeAnalytics();
        }

        [Inject]
        public void Constructor(SettingsScriptableObject settings, ILogger logger)
        {
            this.logger = logger;
            initialize = settings.isAnalyticsEnabled;
        }
    }
}