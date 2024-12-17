using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyProjectileManager : MonoBehaviour
{

    [SerializeField] public AllyProjectileData allyProjectileData;

     

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collided with an object tagged as 'Enemy'");
            EnemyManager enemyManager = other.gameObject.GetComponent<EnemyManager>();
            Debug.Log("collided enemy health value is : " + enemyManager.enemyHealth);
            enemyManager.enemyHealth -= allyProjectileData.enemyDamaging;
            Destroy(gameObject);
        }
        Invoke("DestroySelf", 1f);


    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
