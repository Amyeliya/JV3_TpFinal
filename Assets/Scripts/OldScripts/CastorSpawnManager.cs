// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Meta.XR.MRUtilityKit;

// public class CastorSpawnManager : MonoBehaviour
// {
//     [SerializeField] private float spawnTimer = 1;
//     [SerializeField] private GameObject prefabToSpawn;
//     [SerializeField] private float minEdgeDistance = 0.3f;
//     public MRUKAnchor.SceneLabels spawnLabels;
//     private float normalOffset;

//     public int spawnTry = 1000;

//     private float timer;

//     void Start()
//     {
        
//     }

//     void Update()
//     {
//         if(!MRUK.Instance && !MRUK.Instance.IsInitialized){
//             return;
//         }

//         timer += Time.deltaTime;
//         if(timer > spawnTimer){
//             SpawnEnnemi();
//             timer -= spawnTimer;
//         }
//     }

//     public void SpawnEnnemi(){
//         MRUKRoom room = MRUK.Instance.GetCurrentRoom();

//         int currentTry = 0;

//         while(currentTry < spawnTry){
//             bool hasFoundPosition = room.GenerateRandomPositionOnSurface(MRUK.SurfaceType.FACING_UP, minEdgeDistance, LabelFilter.Included(spawnLabels), out Vector3 pos, out Vector3 norm);

//             if(hasFoundPosition){
//             Vector3 randomPositionNormalOffset = pos + norm *  normalOffset;
//             randomPositionNormalOffset.y = 0;

//             Instantiate(prefabToSpawn,randomPositionNormalOffset, Quaternion.identity);

//             return;
//             }
//             else{
//             currentTry++;
//             }
//         }
//     }
// }
