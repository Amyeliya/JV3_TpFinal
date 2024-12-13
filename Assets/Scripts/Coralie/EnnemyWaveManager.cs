using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyWaveManager : MonoBehaviour
{
   [SerializeField] EnnemySpawner ennemySpawner;
   [SerializeField] private enemySpawner gameManager;
 
    void Start()
    {
        InvokeRepeating("decompte", 1f, 3f);
        StartCoroutine(StopInvokeAfterTime(15f));
        
        InvokeRepeating("decompte2", 10f, 1f);
        StartCoroutine(StopInvokeAfterTime2(50f));
 
    }
    void Update()
    {
        if (gameManager.enemyCount == 25)
        {
            CancelInvoke("decompte");
            Debug.Log("CancelInvboke was called ewofhwdfhwdikjfdoufisfujdhfikjsdfosjdhfdsjhf");
        }
    }
    public void decompte()
    {
        
        ennemySpawner.SpawnAvion();
        Debug.Log("DECOMPTE");
 
    }
       public void decompte2()
    {
        
        ennemySpawner.SpawnAvion();
        Debug.Log("DECOMPTE2222");
    }
        private IEnumerator StopInvokeAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        CancelInvoke("decompte");
    }
 
        private IEnumerator StopInvokeAfterTime2(float delay2)
    {
        yield return new WaitForSeconds(delay2);
        CancelInvoke("decompte2");
    }
 
}
