using UnityEngine;

[CreateAssetMenu(fileName = "analytics_enabled", menuName = "Analytics", order = 0)]
public class AnalyticsScriptableObject : ScriptableObject
{
    public bool isEnabled = true;
}