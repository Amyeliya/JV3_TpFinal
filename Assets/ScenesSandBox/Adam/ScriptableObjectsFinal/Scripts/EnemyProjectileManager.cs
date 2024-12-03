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
            Debug.Log("collided enemy health value is : " + allyManager.allyData.allyHealth);
            allyManager.allyData.allyHealth -= enemyProjectileData.allyDamaging;
            Destroy(gameObject);
        }
        /*Debug.Log("Collided with: " + other.gameObject.name);
        
        Debug.Log("enemy script reference is : " + enemyManager);*/

       //allyProjectileDamageValue = allyProjectileData.enemyDamaging;
       
    }

}
