using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAllyProjectileData", menuName = "AllyProjectile/AllyProjectileData")]
public class AllyProjectileData : ScriptableObject
{

    [SerializeField] public int enemyDamaging;

}
