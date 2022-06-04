using UnityEngine;

public class AttackTornadoDamage : MonoBehaviour
{
    [Min(0)]
    [Tooltip("Damage dealt for each attack hit.")]
    public float damagePerHit = 5.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            enemyHealth.AdjustCurrentHealth(-damagePerHit);
        }
    }
}
