using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{
    
    
    [SerializeField] public float fireRate;
    [SerializeField] public float movementSpeed;
    [SerializeField] public bool isRangedEnemy = false;
    [SerializeField] public bool isKamikazeEnemy = false;
    [SerializeField] public bool isPlaneEnemy = false;
    public int defaultKamikazeEnemyHealth = 135;
    public int defaultRangedEnemyHealth = 350;
    public int defaultAirEnemyHealth = 50;

    

}
