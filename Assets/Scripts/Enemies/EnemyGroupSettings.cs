using UnityEngine;

[System.Serializable]
public class EnemyGroupSettings
{
    [Range(2, 512)]
    [Tooltip("The total average number of enemies in the group.")]
    public int groupSize = 128;
    [Range(0, 128)]
    [Tooltip("The number of enemies in the group will vary by +/- a random number between 0 and the variance value.")]
    public int groupSizeVariance = 32;
    [Range(0, 100)]
    [Tooltip("Percentage chance that a boss will spawn with this group.")]
    public int spawnBossChance = 0;
}
