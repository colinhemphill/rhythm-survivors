using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;

    private float currentHealth;
    private bool playerIsDead;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (playerIsDead)
        {
            return;
        }
        if (currentHealth <= 0)
        {
            PlayerHealthDepleted();
        }
    }

    /// <summary>
    /// Cause damage or heal the player.
    /// </summary>
    /// <param name="healthChange">Positive or negative <code>float</code> to adjust health by</param>
    public void AdjustCurrentHealth(float healthChange)
    {
        currentHealth += healthChange;
    }

    /// <summary>
    /// The player has no more health, i.e. they are dead.
    /// </summary>
    private void PlayerHealthDepleted()
    {
        Debug.Log("YOU ARE DEAD");
        playerIsDead = true;
    }
}
