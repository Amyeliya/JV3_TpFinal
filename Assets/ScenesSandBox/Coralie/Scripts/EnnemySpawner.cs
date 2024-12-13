using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class EnnemySpawner : MonoBehaviour
{
      // [SerializeField] private GameObject avionPrefab;  // Le prefab de l'avion à instancier
    // [SerializeField] private Transform effectOrigin;  // Origine du Building Block Effect Mesh (ou une zone centrale)
    // [SerializeField] private Vector3 spawnAreaSize = new Vector3(50f, 0f, 50f);  // Taille de la zone de spawn (X, Y, Z)
    // [SerializeField] private float spawnHeight = 10f;  // Hauteur où l'avion doit apparaître
 
    [SerializeField] private FindSpawnPositions spawnPositions;

 
 
    void Awake()
    {
        spawnPositions.SpawnAmount = 0;
    }
 
    void Start()
    {
        SpawnAvion();
    }
 
    public void SpawnAvion()
    {
       
        spawnPositions.SpawnAmount = 1;
        spawnPositions.StartSpawn();
    }
 
        // Générer une position aléatoire dans la zone de spawn
        // Vector3 randomPosition = GetRandomPositionInArea(effectOrigin.position, spawnAreaSize);
 
        // Ajouter la hauteur pour placer l'avion au-dessus du terrain ou de l'environnement
        //randomPosition.y += spawnHeight;
 
        // Instancier l'avion à la position calculée
        //Instantiate(avionPrefab, randomPosition, Quaternion.identity);
 
        // Debug pour vérifier la position de l'avion
        //Debug.Log("Position de l'avion générée : " + randomPosition);
 
    // Cette fonction génère un point aléatoire dans une zone délimitée par une taille spécifiée
    // Vector3 GetRandomPositionInArea(Vector3 areaCenter, Vector3 areaSize)
    // {
    //     // Calculer des coordonnées aléatoires dans l'espace délimité par areaCenter et areaSize
    //     float randomX = Random.Range(areaCenter.x - areaSize.x / 2f, areaCenter.x + areaSize.x / 2f);
    //     float randomZ = Random.Range(areaCenter.z - areaSize.z / 2f, areaCenter.z + areaSize.z / 2f);
 
    //     // La coordonnée Y peut être ajustée selon la hauteur de l'avion
    //     return new Vector3(randomX, areaCenter.y, randomZ);
    // }
}
