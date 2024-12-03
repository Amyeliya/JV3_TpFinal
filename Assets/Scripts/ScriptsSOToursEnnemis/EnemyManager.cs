using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] public EnemyData enemyData;
    [SerializeField] public int enemyHealth = 225;

    private void Start() {
    Debug.Log("Self SO reference  de l'ennemi: " + enemyData);
        if (enemyData.isRangedEnemy == true)
        {
            enemyHealth = enemyData.defaultRangedEnemyHealth;
        }
        if (enemyData.isPlaneEnemy)
        {
            enemyHealth = enemyData.defaultAirEnemyHealth;
        }
        else
        {
            detectionRange = 0f;
            enemyHealth = enemyData.defaultKamikazeEnemyHealth;
        }
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>

    [Header("Detection Settings")]
    [Tooltip("Le tag des cibles à détecter.")]
    public string targetTag = "Ally";

    [Tooltip("Portée maximale pour détecter les cibles.")]
    public float detectionRange = 10f;

    [Header("Projectile Settings")]
    [Tooltip("Prefab du projectile à lancer.")]
    public GameObject projectilePrefab;

    [Tooltip("Position de départ du projectile.")]
    public Transform enemyLaunchPoint;

    [Tooltip("Vitesse du projectile.")]
    public float projectileSpeed = 10f;

    [Tooltip("Intervalle de tir (en secondes).")]
    public float fireInterval = 1f;

    private float fireCooldown;

    void Update()
    {
        //Debug.Log("Update dans enemymanager pour shooter called");
        fireCooldown -= Time.deltaTime;

        GameObject nearestTarget = FindNearestTarget();
        if (nearestTarget != null && fireCooldown <= 0f)
        {
            LaunchProjectile(nearestTarget);
            fireCooldown = fireInterval;
        }
        if (enemyHealth <= 0)
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
        if (projectilePrefab != null && enemyLaunchPoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, enemyLaunchPoint.position, Quaternion.identity);
            Vector3 direction = (target.transform.position - enemyLaunchPoint.position).normalized;
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = direction * projectileSpeed;
            }
        }
    }
}
