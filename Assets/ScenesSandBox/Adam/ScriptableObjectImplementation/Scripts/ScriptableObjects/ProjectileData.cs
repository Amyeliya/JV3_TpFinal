using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileData : ScriptableObject
{
    
    [SerializeField] public GameObject projectile;
    [SerializeField] public int damage = 15;
    [SerializeField] public float speed = 0;

}
