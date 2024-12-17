using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f; // Vitesse du projectile
    [SerializeField] private float lifeTime = 1.5f; // Durée de vie du projectile avant disparition

    private Vector3 direction; // Direction initiale du projectile
    private Lanceur lanceur; // Référence au lanceur pour notifier la fin du projectile

    public void Initialize(Lanceur lanceurInstance, Transform target, float speed)
    {
        lanceur = lanceurInstance;
        this.speed = speed;

        // Calculer la direction initiale vers la cible et normaliser
        direction = (target.position - transform.position).normalized;

        // Orienter le projectile pour qu'il pointe dans la direction initiale
        transform.LookAt(target.position);

        // Détruire le projectile après "lifeTime" secondes et notifier le lanceur
        Invoke(nameof(NotifyAndDestroy), lifeTime);
    }

    private void Update()
    {
        // Déplacer le projectile en ligne droite dans la direction initiale
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifier si la collision est avec la cible
        if (collision.transform.CompareTag("Target"))
        {
            Debug.Log("Projectile a touché la cible !");

            // Notifier le lanceur que le projectile a atteint la cible
            NotifyAndDestroy();
        }
    }

    private void NotifyAndDestroy()
    {
        // Notifier le lanceur pour réinitialiser "hasLaunched"
        lanceur.OnProjectileEnd();

        // Détruire le projectile
        Destroy(gameObject);
    }
}
