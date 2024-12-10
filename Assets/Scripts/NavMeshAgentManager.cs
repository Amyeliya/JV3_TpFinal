using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshAgentManager : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public float speed = 1;

    private GameObject mainTarget;
    
    void Start()
    {
        mainTarget = GameObject.FindGameObjectWithTag("Ally");
    }

    
    void Update()
    {
        Vector3 targetPosition = mainTarget.transform.position;

        agent.SetDestination(targetPosition);
        agent.speed = speed;
    }
}
