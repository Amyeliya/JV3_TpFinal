using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileManager : MonoBehaviour
{
    [SerializeField] public EnemyProjectileData enemyProjectileData;

private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Ally"))
        {
            Debug.Log("Collided with an object tagged as 'Ally'");
            AllyTowerManager allyManager = other.gameObject.GetComponent<AllyTowerManager>();
            Debug.Log("collided ally health value is : " + allyManager.allyHealth);
            allyManager.allyHealth -= enemyProjectileData.allyDamaging;
            Destroy(gameObject);
        }
        Invoke("DestroySelf", 0.2f);

    
        /*Debug.Log("Collided with: " + other.gameObject.name);
        
        Debug.Log("enemy script reference is : " + enemyManager);*/

       //allyProjectileDamageValue = allyProjectileData.enemyDamaging;
       
    }
private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
