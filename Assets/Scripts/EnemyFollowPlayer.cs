using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float enemySpeed;
    private Rigidbody enemyRb;
    public GameObject player;
    private EnemyHearsPlayer enemyHearsPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        enemyHearsPlayer = GetComponentInChildren<EnemyHearsPlayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyHearsPlayer.isEnemyActive == true)
        {
            FollowPlayer();
        }
        
    }
    private void FollowPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        enemyRb.MovePosition(transform.position + direction * enemySpeed * Time.fixedDeltaTime);
    }
}

