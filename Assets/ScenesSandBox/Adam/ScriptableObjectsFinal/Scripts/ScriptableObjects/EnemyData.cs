using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{
    
    [SerializeField] public int enemyHealth;
    [SerializeField] public float fireRate;
    [SerializeField] public float movementSpeed;
    public int defaultKamikazeEnemyHealth = 135;
    public int defaultRangedEnemyHealth = 350;
    [SerializeField] public bool isRangedEnemy = false;
    [SerializeField] public bool isKamikazeEnemy = false;
    

}
