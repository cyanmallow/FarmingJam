using UnityEngine;

[CreateAssetMenu(fileName = "SpawnManager", menuName = "Scriptable Objects/SpawnManager")]
public class SpawnManagerScriptableObject : ScriptableObject
{
    public string prefabName;
    public int numberOfPrefabs;
    public Vector3[] spawnPoints;


}
