using UnityEngine;

public class InstantiateRandomEnemyPrefab : MonoBehaviour
{
    public GameObject[] enemyPrefabs;

    private bool ready = false;
    private GameObject randomEnemyPrefab;

    private void Awake()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0)
        {
            Debug.LogError("You must attach at least one enemy prefab to InstantiateRandomEnemyPrefab.");
        }
        else
        {
            ready = true;
            randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        }
    }

    private void Start()
    {
        if (!ready)
        {
            return;
        }

        GameObject enemy = Instantiate<GameObject>(randomEnemyPrefab, transform.position, transform.rotation);
        enemy.transform.parent = transform;
    }
}
