using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public LevelData levelData;
    public bool tourPrincipalePlaced;
    public bool gamefirstStart;
    private UIManager uiManager;

private void Start(){
    levelData.score = 0;
    levelData.wave = 1;
    levelData.ennemiesCount = 0;
    uiManager.UpdateUI();
}

}


