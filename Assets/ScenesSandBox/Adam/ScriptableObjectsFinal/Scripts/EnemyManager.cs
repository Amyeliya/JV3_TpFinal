using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] public EnemyData enemyData;

    private void Start() {
    Debug.Log("Self SO reference  de l'ennemi: " + enemyData);
        
    }
    
}
