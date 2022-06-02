using UnityEngine;

[System.Serializable]
public class EnemyGroupSettings
{
    [Range(2, 256)]
    public int groupSize = 50;
    [Range(0, 32)]
    public int groupSizeVariance = 10;
    [Range(0, 100)]
    public int spawnBossChance = 0;
}
