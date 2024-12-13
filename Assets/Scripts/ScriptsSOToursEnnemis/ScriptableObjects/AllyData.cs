using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAllyData", menuName = "Ally/AllyData")]
public class AllyData : ScriptableObject
{
    
    [SerializeField] public float fireDelay;
    [SerializeField] public float targetingRadius;
    [SerializeField] public float projectileSpeed;
    [SerializeField] public GameObject allyProjectilePrefab;
    [SerializeField] public bool isStrongAlly = false;
    [SerializeField] public bool isWeakAlly = false;
    public int defaultWeakAllyTowerHealth = 500;
    public int defaultStrongAllyTowerHealth = 1500;
}
