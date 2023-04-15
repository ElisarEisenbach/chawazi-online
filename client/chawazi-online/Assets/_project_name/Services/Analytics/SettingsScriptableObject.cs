using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "settings_file", menuName = "Settings Objects/Empty", order = 0)]
public class SettingsScriptableObject : ScriptableObject
{
    [FormerlySerializedAs("isEnabled")] public bool isAnalyticsEnabled = true;
}