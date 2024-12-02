using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyProjectileManager : MonoBehaviour
{

    [SerializeField] public AllyProjectileData allyProjectileData;

    private void Awake() {
        Debug.Log("current Ally projectile damage value is : " + allyProjectileData.enemyDamaging);
    } 

}
