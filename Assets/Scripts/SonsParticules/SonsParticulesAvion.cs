using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonsParticulesAvion : MonoBehaviour
{
    [SerializeField] private AudioClip _soundClip;  
    [SerializeField] private GameObject _boom;
    private AudioSource _audioSource; 

    [SerializeField] private AudioClip _soundBoom;  
    private AudioSource _audioBoom; 


    private LevelData levelData;

    private WaveAndSpawnManager waveAndSpawnManager;

    private void Start() {
        levelData = Resources.Load<LevelData>("LevelData");
        
        GameObject gameManager = GameObject.Find("GameManager");
        waveAndSpawnManager = gameManager.GetComponent<WaveAndSpawnManager>();
    }

    private void OnDestroy()
    {
        waveAndSpawnManager.OnEnemyKilled();
        AudioSource.PlayClipAtPoint(_soundClip, transform.position);

    }

    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.tag == "Ally" ){

            Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f);

            GameObject BoomInstance = Instantiate(_boom, transform.position, rotation); /*== Pour faire boom == */

            AudioSource.PlayClipAtPoint(_soundClip, transform.position);

            AudioSource.PlayClipAtPoint(_soundBoom, transform.position);

            levelData.ennemiesCount--;

            waveAndSpawnManager.OnEnemyKilled();

            Destroy(BoomInstance, 5f);

            Destroy(gameObject);
        }

        Debug.Log("=====================================================================Collided with: " + other.gameObject.name);
    
    }
}
