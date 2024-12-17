using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndManager : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private string FinJeuVictoire = "FinJeuVictoire";
    [SerializeField] private string FinJeuDefaite = "FinJeuDefaite";
    private GameObject mainTower;
    private bool gameEnded = false;
    private bool mainTowerHasBeenAssigned = false; // Ajout d'un indicateur pour savoir si la tour principale a été assignée

    public void SetMainTower(GameObject tower)
    {
        mainTower = tower;
        mainTowerHasBeenAssigned = true; // Marquer la tour principale comme assignée
        Debug.Log($"Tour principale assignée : {tower.name}");
    }

    private void Update()
    {
        if (gameEnded) return;

        // Vérifiez uniquement la défaite si la tour principale a été assignée
        if (mainTowerHasBeenAssigned && mainTower == null)
        {
            Debug.Log("Condition de défaite détectée : La tour principale est détruite.");
            EndGame(false);
        }
    }

    public void EndGame(bool victory)
    {
        gameEnded = true;

        if (victory)
        {
            Debug.Log("Victoire ! Chargement de la scène de victoire.");
            SceneManager.LoadScene(FinJeuVictoire);
        }
        else
        {
            Debug.Log("Défaite ! Chargement de la scène de défaite.");
            SceneManager.LoadScene(FinJeuDefaite);
        }
    }
}
