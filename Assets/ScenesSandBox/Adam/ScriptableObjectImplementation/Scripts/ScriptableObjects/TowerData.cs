using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTowerData", menuName = "Tower/TowerData")]
public class TowerData : ScriptableObject
{

    [SerializeField] public int healthPoints = 100;
    [Range(2f, 5f)] public float attackRate = 0;
    [SerializeField] public float projectileSpeed = 10f;
    [SerializeField] public GameObject projectile;
    [SerializeField] public Transform currentTarget;
    [SerializeField] public bool projectileLaunched = false;

    
}
