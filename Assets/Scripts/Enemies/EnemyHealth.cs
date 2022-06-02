using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    public float maxHealth { get; set; }
    public float currentHealth { get; set; }
    public bool isHealthDepleted { get; set; }

    private void Start()
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
        currentHealth += healthChange;
    }

    public void HealthDepleted()
    {
        isHealthDepleted = true;
    }
}
