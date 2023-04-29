using UnityEngine;

[CreateAssetMenu(fileName = "settings_file", menuName = "Settings Objects/Empty", order = 0)]
public class SettingsScriptableObject : ScriptableObject
{
    public bool isAnalyticsEnabled = true;
}