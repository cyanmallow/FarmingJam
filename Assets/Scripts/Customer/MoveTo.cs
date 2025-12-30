using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    
    private int count;
    private NavMeshAgent agent;

    public Transform entrance;
    public Transform shelf;
    public Transform checkout;
    public Transform leave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        count = 0;
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            Walk();

            //// check if agent has reached destination
            //Debug.Log("Reached destination, count = " + count);
        }

    }
    private void Walk()
    {
        if (agent.pathPending) {
            return;
        }

        if (agent.remainingDistance > agent.stoppingDistance) {
            return;
        }

        switch (count)
        {
            case 0:
                agent.destination = entrance.position;
                count++;
                break;
            case 1:
                agent.destination = shelf.position;
                count++;
                break;
            case 2:
                agent.destination = checkout.position;
                count++;
                break;
            case 3:
                agent.destination = entrance.position;
                count++;
                break;
            case 4:
                agent.destination = leave.position;
                break;
        }
    }
}
