using UnityEngine;

[System.Serializable]
public class PlayerAttackSettings
{
    public enum AttackTiming { Repeating, Continuous };

    [Tooltip("The prefab to display alongside this attack effect.")]
    public GameObject effectPrefab;

    [Header("Attack Timing")]
    [Space]

    [Tooltip("Select 'Repeating' if the attack triggers and repeats after a delay. Select 'Continuous' if it is a passive attack.")]
    public AttackTiming attackTiming = AttackTiming.Repeating;

    [ConditionalEnumShow("attackTiming", 0)]
    [Min(0)]
    [Tooltip("The time in seconds before the attack repeats.")]
    public float repeatDelay = 3.0f;

    [ConditionalEnumShow("attackTiming", 0)]
    [Min(0)]
    [Tooltip("Max speed at which the attack moves on screen.")]
    public float movementSpeed = 5.0f;

    [ConditionalEnumShow("attackTiming", 0)]
    [Min(0)]
    [Tooltip("Distance which the attack attempts to travel while active;")]
    public float targetDistance = 15.0f;
}
