using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject spawnZone;
    private float _interval = 0.5f;

    private void spawnEnemy()
    {
        Transform spawnZoneTransform = spawnZone.transform;
        Vector3 spawnZoneScale = spawnZoneTransform.localScale;
        Vector3 spawnZonePosition = spawnZoneTransform.position;

        Vector3 randomPosition = new Vector3(
            Random.Range(spawnZonePosition.x - spawnZoneScale.x / 2, spawnZonePosition.x + spawnZoneScale.x / 2),
            Random.Range(spawnZonePosition.y - spawnZoneScale.y / 2, spawnZonePosition.y + spawnZoneScale.y / 2),
            Random.Range(spawnZonePosition.z - spawnZoneScale.z / 2, spawnZonePosition.z + spawnZoneScale.z / 2)
        );
        Instantiate(enemy, randomPosition, Quaternion.identity);
    }

    private void Start() {
        if(1 == 1)
        {
        InvokeRepeating("spawnEnemy", 0f, _interval);

        }
    }

}
