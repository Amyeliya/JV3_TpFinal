using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField] SpawnTower spawnTower;

    public void TowerAppear(GameObject towerPrefab)
    {
        spawnTower.towerPrefab = towerPrefab;
    }
}
