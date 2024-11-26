using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshAgentManager : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public float speed = 1;
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 targetPosition = Camera.main.transform.position;

        agent.SetDestination(targetPosition);
        agent.speed = speed;
    }
}
