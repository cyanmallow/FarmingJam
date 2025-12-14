using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "LightingPresets", menuName = "ScriptableObjects/LightingPresets", order = 1)]
public class LightingPresets : ScriptableObject
{
    public Gradient ambientColor;
    public Gradient directionalLightColor;
    public Gradient fogColor;
}
