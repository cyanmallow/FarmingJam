using System;
using UnityEngine;
using UnityEngine.AI;

public class CustomerWalking : MonoBehaviour
{
    private NavMeshAgent agent;
    // list of waypoints for the customer to walk to
    public GameObject[] waypoints;
    private int count;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            Walk();

        }
    }

    private void Walk()
    {
        if (agent.pathPending)
        {
            return;
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            return;
        }

        for (int i = 0; i < waypoints.Length; i++)
        {
            if (count % waypoints.Length == i)
            {
                agent.destination = waypoints[i].transform.position;
                count++;
                break;
            }
        }
    }
}
