using System.Collections;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public int maxEnemyGroups = 20;
    public float spawnIntervalSeconds = 20.0f;
    public GameObject playfield;
    public EnemyGroup[] enemyGroupPrefabs;

    private float constrictSpawnBounds = 50.0f;
    private int currentEnemyGroups = 0;
    private Bounds playfieldBounds;
    private IEnumerator spawnEnemiesCoroutine;

    private void Awake()
    {
        playfieldBounds = new BoundsUtils().GetMaxBounds(playfield);
        spawnEnemiesCoroutine = SpawnEnemy();
    }

    private void Start()
    {
        StartCoroutine(spawnEnemiesCoroutine);
    }

    IEnumerator SpawnEnemy()
    {
        while (currentEnemyGroups < maxEnemyGroups)
        {
            EnemyGroup randomEnemyGroup = enemyGroupPrefabs[Random.Range(0, enemyGroupPrefabs.Length)];
            float xSpawnPoint = Random.Range(-playfieldBounds.extents.x + constrictSpawnBounds, playfieldBounds.extents.x - constrictSpawnBounds);
            float zSpawnPoint = Random.Range(-playfieldBounds.extents.z + constrictSpawnBounds, playfieldBounds.extents.z - constrictSpawnBounds);
            Vector3 spawnPos = new Vector3(xSpawnPoint, 0, zSpawnPoint);

            EnemyGroup enemyGroup = Instantiate<EnemyGroup>(randomEnemyGroup, spawnPos, randomEnemyGroup.transform.rotation);
            enemyGroup.transform.parent = transform;

            currentEnemyGroups++;

            yield return new WaitForSeconds(spawnIntervalSeconds);
        }
    }
}
