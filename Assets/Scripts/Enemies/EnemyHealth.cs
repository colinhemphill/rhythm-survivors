using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [field: SerializeField]
    public float maxHealth { get; set; }
    public float currentHealth { get; set; }
    public bool isHealthDepleted { get; set; }
    [Tooltip("A prefab effect to display when an enemy is hit by the attack")]
    public GameObject damageHitEffect;

    private void Awake()
    {
        ResetHealth();
    }

    private void Update()
    {
        if (isHealthDepleted)
        {
            return;
        }
        else if (currentHealth <= 0)
        {
            HealthDepleted();
        }
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void AdjustCurrentHealth(float healthChange)
    {
        if (healthChange < 0)
        {
            Instantiate(damageHitEffect, new Vector3(transform.position.x, 1, transform.position.z), transform.rotation);
        }
        currentHealth += healthChange;
    }

    public void HealthDepleted()
    {
        Destroy(gameObject);
    }
}
