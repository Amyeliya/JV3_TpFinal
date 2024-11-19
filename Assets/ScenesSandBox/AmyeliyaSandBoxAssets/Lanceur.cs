using UnityEngine;

public class Lanceur : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab; // Le prefab du projectile à instancier
    [SerializeField] private Transform target; // Cible vers laquelle le projectile va se diriger
    [SerializeField] private float launchSpeed = 10f; // Vitesse du projectile

    private bool hasLaunched = false;

    private void Update()
    {
        // Vérifier si un projectile n'a pas été lancé et lancer si possible
        if (!hasLaunched)
        {
            RelacherProjectile();
            hasLaunched = true;
        }
    }

    private void RelacherProjectile()
    {
        if (projectilePrefab != null && target != null)
        {
            // Instancier le projectile à la position du lanceur
            GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, transform.rotation);

            // Récupérer le script Projectile et initialiser avec la cible et la vitesse
            Projectile projectileScript = projectileInstance.GetComponent<Projectile>();
            if (projectileScript != null)
            {
                projectileScript.Initialize(this, target, launchSpeed);
            }
        }
        else
        {
            Debug.LogWarning("Le prefab du projectile ou la cible n'est pas définie !");
        }
    }

    // Méthode appelée par le projectile pour réinitialiser "hasLaunched"
    public void OnProjectileEnd()
    {
        hasLaunched = false; // Permet de relancer un nouveau projectile
    }
}
