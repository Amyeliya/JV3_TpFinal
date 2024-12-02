using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileManager : MonoBehaviour
{
    [SerializeField] public EnemyProjectileData enemyProjectileData;

    private void Awake() {
        Debug.Log("current Enemy projectile damage value is : " + enemyProjectileData.allyDamaging);
    }

}
