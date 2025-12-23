using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    
    private int count = 0;
    private NavMeshAgent agent;

    public Transform entrance;
    public Transform shelf;
    public Transform checkout;
    public Transform leave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            Walk();
        }
            
    }
    private void Walk()
    {
        count++;

        if (count == 1)
        {
            agent.destination = entrance.position;
        }
        if (count == 2)
        {
            agent.destination = shelf.position;
        }
        if (count == 3)
        {
            agent.destination = checkout.position;
        }
        if (count == 4)
        {
            agent.destination = entrance.position;
        }
        if (count == 5)
        {
            agent.destination = leave.position;
        }
    }
}
