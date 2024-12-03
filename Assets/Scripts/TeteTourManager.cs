using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeteTourManager : MonoBehaviour
{
    [Header("Detection Settings")]
    [Tooltip("Le tag des cibles à détecter.")]
    public string targetTag = "Enemy";

    [Tooltip("Portée maximale pour détecter les cibles.")]
    public float detectionRange = 10f;

    void Update()
    {

        GameObject nearestTarget = FindNearestTarget();
         if (nearestTarget != null)
        {
            transform.LookAt(nearestTarget.transform);
        }
    }
    
    GameObject FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject nearestTarget = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget < shortestDistance && distanceToTarget <= detectionRange)
            {
                shortestDistance = distanceToTarget;
                nearestTarget = target;
            }
        }

        return nearestTarget;
    }
}
