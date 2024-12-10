using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject avionPrefab;
    [SerializeField] private float minX= -10f;
    [SerializeField] private float maxX = 10f;
    [SerializeField] private float minY = 5f;
    [SerializeField] private float maxY = 15f;
    [SerializeField] private float minZ = -10f;
    [SerializeField] private float maxZ = 10f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnAvion();
    }

    private void SpawnAvion()
    {
        float randomX = Random.Range(minX,maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 randomPosition =  new Vector3(randomX, randomY, randomZ);
        Instantiate(avionPrefab, randomPosition, Quaternion.identity);
    }
}
