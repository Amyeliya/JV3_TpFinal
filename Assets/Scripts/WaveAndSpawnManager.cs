using System.Collections;
using Meta.XR.MRUtilityKit;
using UnityEngine;

public class WaveAndSpawnManager : MonoBehaviour
{
    [SerializeField] private FindSpawnPositions spawnPositionsCastor; // Spawner pour Castors
    [SerializeField] private FindSpawnPositions spawnPositionsCamion; // Spawner pour Camions
    [SerializeField] private FindSpawnPositions spawnPositionsAvion; // Spawner pour Camions
    [SerializeField] private GameManager gameManager;                // Gestionnaire principal
    [SerializeField] private LevelData levelData;                    // Données du niveau



    [SerializeField] private UIManager uiManager;

    private GameEndManager gameEndManager;


    private bool wave1Started = false;
    private bool wave2Started = false;

    private float spawnIntervalCastor = 0.5f; // Intervalle de spawn pour Castors
    private float spawnIntervalCamion = 0.7f; // Intervalle de spawn pour Camions
    private float spawnIntervalAvion = 1.5f; // Intervalle de spawn pour Avions
    private int maxEnemiesWave1 = 10;         // Nombre max d'ennemis pour la vague 1
    private int maxEnemiesWave2 = 20;         // Nombre max d'ennemis pour la vague 2
    private int enemiesSpawnedWave1 = 0;      // Total des ennemis générés pour la vague 1
    private int enemiesKilledWave1 = 0;       // Total des ennemis tués pour la vague 1

    private int enemiesSpawnedWave2 = 0;      // Total des ennemis générés pour la vague 2
    private int enemiesKilledWave2 = 0;       // Total des ennemis tués pour la vague 2


    private void Start(){
       gameEndManager = gameManager.GetComponent<GameEndManager>();
    }

    private void Update()
    {
        // Vérifiez si la tour principale a été placée et que le jeu a commencé
        if (gameManager.gamefirstStart == true && !wave1Started)
        {
            StartWave1();
            wave1Started = true;
        }

        // Transition vers la vague 2 après avoir tué tous les ennemis de la vague 1
        if (enemiesKilledWave1 >= maxEnemiesWave1)
        {
            StartWave2();
            wave2Started = true;
        }
    }

    void LateUpdate(){
        if (levelData.wave == 2 && levelData.score >= 30)
        {
            gameEndManager.EndGame(true);
        }
    }

    private void StartWave1()
    {
        Debug.Log("Wave 1 starts");
        levelData.wave = 1;

        // Démarrer les coroutines pour spawner Castors et Camions
        StartCoroutine(SpawnEnemies(spawnPositionsCastor, spawnIntervalCastor, maxEnemiesWave1 / 2, "Castor", true, false));
        StartCoroutine(SpawnEnemies(spawnPositionsCamion, spawnIntervalCamion, maxEnemiesWave1 / 2, "Camion", true, false));
        StartCoroutine(SpawnEnemies(spawnPositionsAvion, spawnIntervalAvion, maxEnemiesWave1 / 2, "Camion", true, false));
    }

    private void StartWave2()
    {
        Debug.Log("Wave 2 starts");
        levelData.wave = 2;

        uiManager.UpdateUI();

        // Ajuster les intervalles pour la vague 2
        spawnIntervalCastor = 0.3f;
        spawnIntervalCamion = 0.5f;
        spawnIntervalAvion = 1f;

        // Démarrer les coroutines pour la vague 2
        StartCoroutine(SpawnEnemies(spawnPositionsCastor, spawnIntervalCastor, maxEnemiesWave2 / 2, "Castor", false, true));
        StartCoroutine(SpawnEnemies(spawnPositionsCamion, spawnIntervalCamion, maxEnemiesWave2 / 2, "Camion", false, true));
        StartCoroutine(SpawnEnemies(spawnPositionsAvion, spawnIntervalAvion, maxEnemiesWave2 / 2, "Camion", false, true));
    }

    private IEnumerator SpawnEnemies(FindSpawnPositions spawner, float interval, int maxSpawns, string enemyType, bool isWave1, bool isWave2)
    {

        for (int i = 0; i < maxSpawns; i++)
        {
            if (spawner.SpawnObject == null)
            {
                yield break;
            }

            spawner.SpawnAmount = 1; // Spawner un objet à la fois
            spawner.StartSpawn(); // Démarrer le spawn
            levelData.ennemiesCount++;

            if (isWave1)
            {
                enemiesSpawnedWave1++;
            }
            if(isWave2)
            {
                enemiesSpawnedWave2++;
                
            }

            

            yield return new WaitForSeconds(interval); // Attendre avant le prochain spawn
        }
    }

    // Méthode pour appeler lorsqu'un ennemi est tué
    public void OnEnemyKilled()
    {
        if(levelData.ennemiesCount <= 0){

            levelData.ennemiesCount = 0;

        }

        else{

            levelData.ennemiesCount--;
        
        }

        if (wave1Started && !wave2Started)
        {
            enemiesKilledWave1++;

        }

        if (wave2Started)
        {
            enemiesKilledWave2++;
        }

    }
}


