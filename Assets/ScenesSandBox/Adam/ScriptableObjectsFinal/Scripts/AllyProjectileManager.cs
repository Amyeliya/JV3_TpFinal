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
            Debug.Log("collided ally health value is : " + enemyManager.enemyData.enemyHealth);
            enemyManager.enemyData.enemyHealth -= allyProjectileData.enemyDamaging;
            Destroy(gameObject);
        }
        /*Debug.Log("Collided with: " + other.gameObject.name);
        
        Debug.Log("enemy script reference is : " + enemyManager);*/

       //allyProjectileDamageValue = allyProjectileData.enemyDamaging;
       
    }
}
