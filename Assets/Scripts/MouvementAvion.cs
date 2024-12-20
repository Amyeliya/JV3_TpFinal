using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementAvion : MonoBehaviour
{
  [SerializeField] private float moveSpeed = 2f;    // Movement speed
    [SerializeField] private float scaleSpeed = 0.01f;   // Scaling speed
    [SerializeField] private float maxScale = 0.5f;     // Maximum scale the object should reach
    [SerializeField] private float minScale = 0.0001f;
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
       float distanceToTarget = Vector3.Distance(transform.position, target.position);

    // Calculate the scaling factor based on the distance (the closer, the larger the scale)
    // Normalize the distance to go from 0 (minScale) to 1 (maxScale)
    float scaleFactor = Mathf.InverseLerp(1f, 0f, distanceToTarget); // Adjust 10f to the desired max distance for scaling

    // Gradually scale the object from minScale to maxScale
    transform.localScale = Vector3.Lerp(new Vector3(minScale, minScale, minScale), new Vector3(maxScale, maxScale, maxScale), scaleFactor);
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
