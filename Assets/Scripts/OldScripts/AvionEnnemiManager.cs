// using UnityEngine;
 
// public class AvionEnnemiManager : MonoBehaviour
// {
 
//     [SerializeField] Transform player;
//     [SerializeField] float speed = 10f;
//     [SerializeField] float maxSize = 1f;
//     [SerializeField] float minSize = 0.1f;
//     [SerializeField] float heightAbovePlayer = 20f;
//     [SerializeField] GameObject bombPrefab;
//     [SerializeField] Transform bombSpawnPoint;
//     [SerializeField] float bombDropInterval = 1.0f;
 
//     private Vector3 initialPosition;
//     private Vector3 targetPosition;
//     private bool isDroppingBombs = false;
//     private float bombDropTimer = 0f;
 
//     // Start is called before the first frame update
//     void Start()
//     {
//         initialPosition = transform.position;
//         targetPosition = player.position;
 
//         transform.forward = Vector3.forward;
//     }
 
//     // Update is called once per frame
//     void Update()
//     {
//         float horizontalDistance = Vector3.Distance(
//             new Vector3(transform.position.x, 0f, transform.position.z),
//             new Vector3(player.position.x, 0f, player.position.z)
//         );
 
//         Vector3 horizontalDirection = new Vector3(
//             player.position.x - transform.position.x,
//             0f,
//             player.position.z - transform.position.z
//         ).normalized;
 
//         transform.position = Vector3.MoveTowards(
//             transform.position,
//             new Vector3(player.position.x, transform.position.y, player.position.z),
//             speed * Time.deltaTime
//         );
 
//         float sizeFactor = Mathf.Lerp(
//             minSize,
//             maxSize,
//             1 - (horizontalDistance / Vector3.Distance(initialPosition, targetPosition))
//         );
 
//         transform.localScale = new Vector3(sizeFactor, sizeFactor, sizeFactor);
//         transform.position = new Vector3(transform.position.x, heightAbovePlayer, transform.position.z);
 
//         if(isDroppingBombs)
//         {
//             bombDropTimer -= Time.deltaTime;
//             if(bombDropTimer <= 0f)
//             {
//                 DropBomb();
//                 bombDropTimer = bombDropInterval;
//             }
//         }
//     }
 
//     public void StartDroppingBombs()
//     {
//         isDroppingBombs = true;
//         bombDropTimer = 0f;
//     }
 
//     public void StopDroppingBombs()
//     {
//         isDroppingBombs = false;
//     }
 
//     // Méthode publique pour lâcher une bombe
// public void DropBomb()
// {
//     Debug.Log("Méthode DropBomb appelée !");
   
//     // Vérification si les objets sont bien assignés
//     if (bombPrefab == null)
//     {
//         Debug.LogError("Le prefab de bombe n'est pas assigné !");
//     }
//     if (bombSpawnPoint == null)
//     {
//         Debug.LogError("Le BombSpawnPoint n'est pas assigné !");
//     }
   
//     if (bombPrefab != null && bombSpawnPoint != null)
//     {
//         Debug.Log($"Bombe instanciée à la position : {bombSpawnPoint.position}");
//         Instantiate(bombPrefab, bombSpawnPoint.position, Quaternion.identity); // Crée la bombe
//     }
// }
// }