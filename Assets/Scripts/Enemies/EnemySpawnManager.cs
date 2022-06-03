using System.Collections;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("Spawn Settings")]
    [Space]
    public int maxEnemyGroups = 20;
    public float spawnIntervalSeconds = 15.0f;

    [Header("Spawn Locations")]
    [Space]
    public GameObject playfield;
    [Range(1, 100)]
    public int chanceToSpawnNearPlayer = 40;
    public int minDistanceFromPlayer = 25;
    public int maxDistanceFromPlayer = 50;

    [Header("Enemy Groups")]
    [Space]
    public EnemyGroup[] enemyGroupPrefabs;

    private float constrictSpawnBounds = 50.0f;
    private int currentEnemyGroups = 0;
    private GameObject player;
    private Bounds playfieldBounds;
    private IEnumerator spawnEnemiesCoroutine;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
            bool shouldSpawnNearPlayer = currentEnemyGroups == 0 || Random.Range(1, 100) <= chanceToSpawnNearPlayer;
            EnemyGroup randomEnemyGroup = enemyGroupPrefabs[Random.Range(0, enemyGroupPrefabs.Length)];
            Vector3 spawnPos = shouldSpawnNearPlayer ? GetSpawnLocationNearPlayer() : GetRandomSpawnLocation();

            EnemyGroup enemyGroup = Instantiate<EnemyGroup>(randomEnemyGroup, spawnPos, randomEnemyGroup.transform.rotation);
            enemyGroup.transform.parent = transform;

            currentEnemyGroups++;

            yield return new WaitForSeconds(spawnIntervalSeconds);
        }
    }

    private Vector3 GetRandomSpawnLocation()
    {
        float xSpawnPoint = Random.Range(-playfieldBounds.extents.x + constrictSpawnBounds, playfieldBounds.extents.x - constrictSpawnBounds);
        float zSpawnPoint = Random.Range(-playfieldBounds.extents.z + constrictSpawnBounds, playfieldBounds.extents.z - constrictSpawnBounds);
        return new Vector3(xSpawnPoint, 0, zSpawnPoint);
    }

    private Vector3 GetSpawnLocationNearPlayer()
    {
        Vector2 origin = player.transform.position;
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        float randomDistance = Random.Range(minDistanceFromPlayer, maxDistanceFromPlayer);
        Vector2 point = origin + randomDirection * randomDistance;
        return new Vector3(point.x, 0, point.y);
    }
}
