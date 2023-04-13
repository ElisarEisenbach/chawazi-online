using UnityEngine;

namespace _project_name.Services.Analytics
{
    [CreateAssetMenu(fileName = "analytics_enabled", menuName = "Analytics", order = 0)]
    public class AnalyticsScriptableObject : ScriptableObject
    {
        public bool isEnabled;
    }
}