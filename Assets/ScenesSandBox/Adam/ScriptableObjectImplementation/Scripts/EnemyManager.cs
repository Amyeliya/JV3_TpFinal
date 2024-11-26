using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public EnemyData enemyData;
    public void TakeDamage()
    {
        enemyData.healthPoints -= 5;
    }

    public void OnCollisionEnter(Collision other) {
        Debug.Log("collision de enemymanager detected");
        TakeDamage();
        Debug.Log(enemyData.healthPoints);
    }

}
