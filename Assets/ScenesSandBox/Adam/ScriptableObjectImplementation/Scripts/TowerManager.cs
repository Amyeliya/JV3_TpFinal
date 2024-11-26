using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    public TowerData towerData;


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
