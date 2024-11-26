using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
public GameObject particleEffectPrefab; // Particle effect to spawn
    [SerializeField] private GameObject objectToSpawn; // Object to spawn after 3 seconds
    [SerializeField] private Transform spawnLocation; // Location for the spawn (optional)

    [SerializeField] private float delayBeforeObjectSpawn = 3f; // Time to wait before spawning the object
    [SerializeField] private float particleDespawnDelay = 3f; // Time after which the particle effect is destroyed

    public void StartSpawning()
    {
        StartCoroutine(SpawnSequence());
    }

    private IEnumerator SpawnSequence()
    {
        // Step 1: Spawn the particle effect
        GameObject particleEffect = Instantiate(particleEffectPrefab, spawnLocation.position, spawnLocation.rotation);

        // Step 2: Wait for 3 seconds
        yield return new WaitForSeconds(delayBeforeObjectSpawn);

        // Step 3: Spawn the second object at the same position as the particle effect
        GameObject spawnedObject = Instantiate(objectToSpawn, particleEffect.transform.position, Quaternion.identity);

        // Step 4: Wait for 0.5 seconds
        yield return new WaitForSeconds(particleDespawnDelay);

        // Step 5: Destroy the particle effect
        Destroy(particleEffect);
    }

}





