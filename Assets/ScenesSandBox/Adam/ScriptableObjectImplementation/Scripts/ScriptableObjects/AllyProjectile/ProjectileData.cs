using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewProjectileData", menuName = "Projectile/ProjectileData")]
public class ProjectileData : ScriptableObject
{
    public EnemyData enemyData;
    [SerializeField] public int damage = 15;
    [SerializeField] public float speed = 0;

    public void OnCollisionEnter(Collision other) {
        Debug.Log("collision de projectiledata detected");
        enemyData.TakeDamage();
    }

}
