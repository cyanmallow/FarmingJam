using System;
using System.Collections;
using UnityEngine;

public class SpawnManagerSpawner : MonoBehaviour
{
    public GameObject entityToSpawn;
    public SpawnManagerScriptableObject spawnManagerData;
    private int instanceNumber = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEntities();
    }

    private void SpawnEntities()
    {
        int currentSpawnPointIndex = 0;

        for (int i = 0; i < spawnManagerData.numberOfPrefabs; i++)
        {
            // spawn one entity at the current spawn point
            GameObject currentEntity = Instantiate(entityToSpawn, spawnManagerData.spawnPoints[currentSpawnPointIndex], Quaternion.identity);
            // set the name of the spawned entity
            currentEntity.name = spawnManagerData.prefabName + instanceNumber;
            // move to the next spawn point
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnManagerData.spawnPoints.Length;
            instanceNumber++;
            
            // wait for 3 seconds before spawning the next entity
            StartCoroutine(WaitFor3Seconds());
        }
    }

    IEnumerator WaitFor3Seconds()
    {
        yield return new WaitForSeconds(3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
