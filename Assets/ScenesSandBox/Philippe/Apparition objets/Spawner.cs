using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

[SerializeField] private GameObject mySphere1;
[SerializeField] private GameObject mySphere2;
[SerializeField] private GameObject mySphere3;

[SerializeField] private Transform spawnPoint1;
[SerializeField] private Transform spawnPoint2;
[SerializeField] private Transform spawnPoint3;

public void SpawnSphere1()
{
    Instantiate(mySphere1, spawnPoint1.position, Quaternion.identity);
}

public void SpawnSphere2()
{
    Instantiate(mySphere2, spawnPoint2.position, Quaternion.identity);
}

public void SpawnSphere3()
{
    Instantiate(mySphere3, spawnPoint3.position, Quaternion.identity);
}

}
