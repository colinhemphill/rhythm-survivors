using UnityEngine;

[System.Serializable]
public class EnemyGroupSettings
{
    [Range(2, 512)]
    public int groupSize = 128;
    [Range(0, 128)]
    public int groupSizeVariance = 32;
    [Range(0, 100)]
    public int spawnBossChance = 0;
}
