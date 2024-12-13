using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementAvion : MonoBehaviour
{
  [SerializeField] private float moveSpeed = 2f;    // Movement speed
    [SerializeField] private float scaleSpeed = 0.1f;   // Scaling speed
    [SerializeField] private float maxScale = 0.5f;     // Maximum scale the object should reach
    [SerializeField] private string targetTag = "Ally";  // Tag of the target objects

    private Transform target;  // Target object to move towards
    private Vector3 initialScale;  // Initial scale of the object

    void Start()
    {
        initialScale = transform.localScale;  // Store the initial scale of the object
        FindTarget();  // Find the target with the specified tag ("Ally")
    }

    void Update()
    {
        // If a target is found, move towards it
        if (target != null)
        {
            MoveTowardsTarget();
            ScaleObject();
            LookAtTarget();
        }
        else
        {
            // If no target is found, search for it again
            FindTarget();
        }
    }

    // Method to find the closest object with the specified tag
    void FindTarget()
    {
        // Find all GameObjects with the "Ally" tag
        GameObject[] allyObjects = GameObject.FindGameObjectsWithTag(targetTag);

        if (allyObjects.Length > 0)
        {
            float closestDistance = Mathf.Infinity;
            GameObject closestObject = null;

            // Find the closest Ally object
            foreach (GameObject obj in allyObjects)
            {
                float distance = Vector3.Distance(transform.position, obj.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestObject = obj;
                }
            }

            // Set the closest Ally object as the target
            if (closestObject != null)
            {
                target = closestObject.transform;
            }
        }
    }

    // Method to move the object towards the target
    void MoveTowardsTarget()
    {
        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    // Method to scale the object gradually
    void ScaleObject()
    {
        if (transform.localScale.x < maxScale)  // Ensure the object doesn't scale beyond maxScale
        {
            // Gradually scale the object from the initial scale to the maximum scale
            transform.localScale = Vector3.Lerp(initialScale, new Vector3(maxScale, maxScale, maxScale),
                (transform.position - initialScale).magnitude / (target.position - initialScale).magnitude);
        }
    }

    // Method to make the object look at the target
    void LookAtTarget()
    {
        // Calculate the direction from the object to the target
        Vector3 directionToTarget = target.position - transform.position;
        // Make the object face the target
        Quaternion rotation = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * moveSpeed);
    }
}
