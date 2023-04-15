using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _project_name.Services.Analytics
{
    public class InitializeAnalytics : MonoBehaviour
    {
        private List<IAnalytics> analytics;
        private bool initialize;

        private void Start()
        {
            if (initialize)
                foreach (var analytic in analytics)
                    analytic.InitializeAnalytics();
        }

        [Inject]
        public void Constructor(SettingsScriptableObject settings)
        {
            initialize = settings.isAnalyticsEnabled;
        }
    }
}