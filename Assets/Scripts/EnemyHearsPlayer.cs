using UnityEngine;

public class EnemyHearsPlayer : MonoBehaviour
{
    public bool isEnemyActive = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isEnemyActive = true;
            Debug.Log("Enemy has heard the player.");
        }
    }
}
