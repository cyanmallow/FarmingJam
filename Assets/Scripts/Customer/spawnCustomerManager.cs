using System.Collections;
using UnityEngine;

public class spawnCustomerManager : MonoBehaviour
{
    public Vector3[] spawnPoints;
    private int instanceNumber = 0;
    public SetUpCustomer[] customerPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnCustomers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnCustomers()
    {
        int currentSpawnPointIndex = 0; 

        foreach (SetUpCustomer customer in customerPrefab)
        {
            // set the position of the spawn point
            transform.position = spawnPoints[currentSpawnPointIndex];
            // move to the next spawn point
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnPoints.Length;


            // spawn one entity at the current spawn point
            SetUpCustomer currentEntity = Instantiate(customer, spawnPoints[currentSpawnPointIndex], Quaternion.identity);

            // move to the next spawn point
            currentSpawnPointIndex = (currentSpawnPointIndex + 1) % spawnPoints.Length;
            instanceNumber++;


            StartCoroutine(WaitFor3Seconds());
        }
    }


    IEnumerator WaitFor3Seconds()
    {
        yield return new WaitForSeconds(20f);
    }
}
