using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject playfield;
    public GameObject[] enemyTypePrefabs;

    private bool ready = false;
    private float startDelay = 2.0f;
    private float spawnInterval = 3f;
    private float spawnRange = 5;

    private void Awake()
    {
        if (enemyTypePrefabs == null || enemyTypePrefabs.Length == 0)
        {
            Debug.LogError("You must attach at least one enemy type prefab to the EnemySpawnManager.");
        }
        else
        {
            ready = true;
        }
    }

    private void Start()
    {
        if (!ready)
        {
            return;
        }

        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);

    }

    private void SpawnEnemy()
    {
        GameObject randomEnemyType = enemyTypePrefabs[Random.Range(0, enemyTypePrefabs.Length)];
        float xSpawnPoint = Random.Range(-spawnRange, spawnRange);
        float zSpawnPoint = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(xSpawnPoint, 0, zSpawnPoint);

        Instantiate<GameObject>(randomEnemyType, spawnPos, randomEnemyType.transform.rotation);
    }
}
