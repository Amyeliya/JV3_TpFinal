using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyTowerManager : MonoBehaviour
{

    [SerializeField] public AllyData allyData;
    
    [SerializeField] public int allyHealth;

    private void Start() {
        DeclareSelfData();
        if (allyData.isStrongAlly == true)
        {
            allyHealth = allyData.defaultStrongAllyTowerHealth;
        }
        else
        {
            allyHealth = allyData.defaultWeakAllyTowerHealth;
        }
    }
    /*
    private void Start() {
    Debug.Log("Self SO reference  de l'ennemi: " + enemyData);
        if (enemyData.isRangedEnemy == true)
        {
            Debug.Log(" in Start, enemy is ranged bool is true");
            enemyData.enemyHealth = enemyData.defaultRangedEnemyHealth;
        }
        else
        {
            detectionRange = 0f;
            enemyData.enemyHealth = enemyData.defaultKamikazeEnemyHealth;
        }
    }
    */

    private void DeclareSelfData()
    {
        Debug.Log("Self SO reference : " + allyData);
        /*
        Debug.Log("Self fire rate float variable : " + allyData.fireDelay);
        Debug.Log("Self allyHealth int variable : " + allyData.allyHealth);
        */
    }

    /*===========CHATGPT CREATED PROJECTILE SHOOTER===========*/

    [Header("Detection Settings")]
    [Tooltip("Le tag des cibles à détecter.")]
    public string targetTag = "Enemy";

    [Tooltip("Portée maximale pour détecter les cibles.")]
    public float detectionRange = 10f;

    [Header("Projectile Settings")]
    [Tooltip("Prefab du projectile à lancer.")]
    public GameObject projectilePrefab;

    [Tooltip("Position de départ du projectile.")]
    public Transform launchPoint;

    [Tooltip("Vitesse du projectile.")]
    public float projectileSpeed = 10f;

    [Tooltip("Intervalle de tir (en secondes).")]
    public float fireInterval = 1f;

    private float fireCooldown;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        GameObject nearestTarget = FindNearestTarget();
        if (nearestTarget != null && fireCooldown <= 0f)
        {
            LaunchProjectile(nearestTarget);
            fireCooldown = fireInterval;
        }
        if (allyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Trouve l'objet le plus proche avec le tag spécifié.
    /// </summary>
    /// <returns>L'objet le plus proche, ou null s'il n'y en a pas.</returns>
    GameObject FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject nearestTarget = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject target in targets)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget < shortestDistance && distanceToTarget <= detectionRange)
            {
                shortestDistance = distanceToTarget;
                nearestTarget = target;
            }
        }

        return nearestTarget;
    }

    /// <summary>
    /// Lancer un projectile sur la cible spécifiée.
    /// </summary>
    /// <param name="target">La cible à attaquer.</param>
    void LaunchProjectile(GameObject target)
    {
        if (projectilePrefab != null && launchPoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            Vector3 direction = (target.transform.position - launchPoint.position).normalized;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * projectileSpeed;
            }
        }
    }


}
