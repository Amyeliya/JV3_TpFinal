using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAnimation : MonoBehaviour
{

    private Vector3 initialPosition;
    [SerializeField] private Vector3 finalPosition;

    [SerializeField] private float rotationSpeed = 45f;

    private void Awake() {
    
        initialPosition = transform.position;
    }

    private void Update() {
        
        transform.position = Vector3.Lerp(transform.position, finalPosition, 0.1f);

        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnDisable() {
        
        transform.position = initialPosition;

    }


}
