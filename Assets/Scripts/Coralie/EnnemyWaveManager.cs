using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyWaveManager : MonoBehaviour
{
   [SerializeField] EnnemySpawner ennemySpawner;
 
    void Start()
    {
        InvokeRepeating("decompte", 1f, 2f);
 
    }
 
    public void decompte()
    {
 
        ennemySpawner.SpawnAvion();
 
    }
 
}
