using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : ScriptableObject
{
    [SerializeField] public int healthPoints = 50;
    [SerializeField] public int damageDealt = 25;
    [SerializeField] public float movementSpeed = 0;
    [SerializeField] public bool isRanged = false;

}
