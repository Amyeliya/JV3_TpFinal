using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject spawnZone;
    private float _interval = 0.2f;
    private int enemyCount = 0;
    private bool enemiesSpawning = true;
    public int enemiesKilled = 0;
    public bool wave2Done = false;

    private void spawnEnemy()
    {
        if (enemiesSpawning == true)
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
        enemyCount ++;
        //Debug.Log(enemyCount);
        Debug.Log("spawnEnemy is called");
        }
    }

    private void stopSpawningEnemy(){
        enemiesSpawning = false;
    }

    private void startWave2()
    {
        if (wave2Done == false)
        {
        _interval = 0.1f;
        enemyCount = -20;
        enemiesKilled = -20;
        InvokeRepeating("spawnEnemy", 4f, _interval);
        enemiesSpawning = true;
        wave2Done = true;
        Debug.Log("Wave 2 starts now");
        }
    }

    private void Start() {
        InvokeRepeating("spawnEnemy", 0f, _interval);
    }

    private void Update() {
        if (enemyCount == 25)
        {
            stopSpawningEnemy();
        }
        if (enemiesKilled == 25)
        {
            startWave2();
        }
    }

}
