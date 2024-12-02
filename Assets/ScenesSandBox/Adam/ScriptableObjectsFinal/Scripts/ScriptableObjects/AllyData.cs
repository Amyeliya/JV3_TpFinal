using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAllyData", menuName = "Ally/AllyData")]
public class AllyData : ScriptableObject
{
    
    [SerializeField] public int allyHealth;
    [SerializeField] public float fireRate;
}
