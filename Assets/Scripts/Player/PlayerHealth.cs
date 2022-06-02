using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    public float playerMaxHealth = 100.0f;
    public float maxHealth { get; set; }
    public float currentHealth { get; set; }
    public bool isHealthDepleted { get; set; }

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        maxHealth = playerMaxHealth;
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
        animator.SetBool("Death_b", true);
        animator.SetInteger("DeathType_int", 2);
    }
}
