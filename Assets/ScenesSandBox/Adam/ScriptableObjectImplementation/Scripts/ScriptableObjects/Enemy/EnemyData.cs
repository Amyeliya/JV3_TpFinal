using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy/EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] public int healthPoints = 50;
    [SerializeField] public int damageDealt = 25;
    [SerializeField] public float movementSpeed = 0;
    [SerializeField] public bool isRanged = false;

    public void TakeDamage()
    {
        healthPoints -= 15;
        Debug.Log(healthPoints);
    }

}
