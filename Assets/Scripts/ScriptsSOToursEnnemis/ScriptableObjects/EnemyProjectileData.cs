using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyProjectileData", menuName = "EnemyProjectile/EnemyProjectileData")]
public class EnemyProjectileData : ScriptableObject
{

    [SerializeField] public int allyDamaging;

}
