using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField] private SpawnTower spawnTower;

    public void SelectSecondaryTower(GameObject towerPrefab)
    {
        if (spawnTower == null)
        {
            return;
        }

        if (!spawnTower.mainTowerPlaced)
        {
            return;
        }

        spawnTower.selectedTowerPrefab = towerPrefab;
    }
}
