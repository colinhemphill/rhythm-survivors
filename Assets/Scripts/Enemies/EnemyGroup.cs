using System.Collections;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public EnemyGroupSettings settings;
    public GameObject[] potentialEnemyPrefabs;
    public GameObject[] potentialBossPrefabs;

    private bool shouldSpawnBoss = false;
    private bool spawnIsComplete = false;

    public EnemyGroup(EnemyGroupSettings settings)
    {
        this.settings = settings;
    }

    public void Awake()
    {
        shouldSpawnBoss = Random.Range(0, 100) <= settings.spawnBossChance;
    }

    public void Update()
    {
        if (spawnIsComplete && transform.childCount == 0)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        int variance = Random.Range(-settings.groupSizeVariance, settings.groupSizeVariance);
        int enemiesToSpawn = settings.groupSize + variance;

        if (shouldSpawnBoss)
        {
            GameObject randomBossPrefab = potentialBossPrefabs[Random.Range(0, potentialBossPrefabs.Length)];
            GameObject boss = Instantiate(randomBossPrefab);
            boss.transform.parent = transform;
            boss.transform.position = transform.position;
        }

        StartCoroutine(SpawnEnemies(enemiesToSpawn));
    }

    IEnumerator SpawnEnemies(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject randomEnemyPrefab = potentialEnemyPrefabs[Random.Range(0, potentialEnemyPrefabs.Length)];
            GameObject enemy = Instantiate(randomEnemyPrefab);
            enemy.transform.parent = transform;
            enemy.transform.position = transform.position;
            yield return null;
        }
        spawnIsComplete = true;
    }
}
