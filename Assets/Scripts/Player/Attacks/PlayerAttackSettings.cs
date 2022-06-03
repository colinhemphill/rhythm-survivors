using UnityEngine;

[System.Serializable]
public class PlayerAttackSettings
{
    [Tooltip("The prefab to display alongside this attack effect.")]
    public GameObject effectPrefab;
    [Min(0)]
    [Tooltip("The duration of the attack. [0, Infinity]")]
    public float effectDuration;
}
