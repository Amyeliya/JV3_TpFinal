using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Level/LevelData")]
public class LevelData : ScriptableObject
{

    [SerializeField] public int score;

    [SerializeField] public int wave;

    [SerializeField] public int ennemiesCount;

}
