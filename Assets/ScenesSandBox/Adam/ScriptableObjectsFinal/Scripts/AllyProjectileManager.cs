using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyProjectileManager : MonoBehaviour
{

    [SerializeField] public AllyProjectileData allyProjectileData;

    private void Awake() {
        Debug.Log("current Ally projectile damage value is : " + allyProjectileData.enemyDamaging);
    } 

    private void OnCollisionEnter(Collision other) 
    {
        EnemyManager enemyManager = other.gameObject.GetComponent<EnemyManager>();
        Debug.Log("collided enemy health value is : " + enemyManager.enemyData.enemyHealth);
        Debug.Log("enemy script reference is : " + enemyManager);

       allyProjectileDamageValue = allyProjectileData.enemyDamaging;
       
    }
}
