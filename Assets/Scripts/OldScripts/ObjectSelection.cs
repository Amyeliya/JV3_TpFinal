// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class ObjectSelection : MonoBehaviour
// {
//     [SerializeField] private int currentObject;

//     [SerializeField] private Button bouttonDroit;
//     [SerializeField] private Button bouttonGauche;
//     [SerializeField] private Button bouttonSpawnRelated;

//     [SerializeField] private Transform spawnLocation;
//     [SerializeField] private GameObject[] relatedObjects;

    
//     private void Awake() {
//         SelectObject(0);
//     }

//     private void SelectObject(int _index){

//         bouttonGauche.interactable = (_index !=0);
//         bouttonDroit.interactable = (_index != transform.childCount -1);

//         for (int i = 0; i < transform.childCount; i++)
//         {
//             transform.GetChild(i).gameObject.SetActive(i == _index);

//         }
    
//     }

//     public void ChangeObject(int _change){

//         currentObject += _change;
//         SelectObject(currentObject);

//     }

//     public void SpawnRelatedObject() {
//         if (currentObject >= 0 && currentObject < relatedObjects.Length) {
//             GameObject relatedObject = relatedObjects[currentObject];
//             Instantiate(relatedObject, spawnLocation.position, spawnLocation.rotation);
//         }
//     }


// }
