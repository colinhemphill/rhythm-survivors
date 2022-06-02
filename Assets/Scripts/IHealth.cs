public interface IHealth
{
    float maxHealth { get; set; }
    float currentHealth { get; set; }
    bool isHealthDepleted { get; set; }

    /// <summary>
    /// Set <code>currentHealth</code> to <code>maxHealth</code>
    /// </summary>
    void ResetHealth();

    /// <summary>
    /// Cause damage or heal the creature.
    /// </summary>
    /// <param name="healthChange">Positive or negative <code>float</code> to adjust health by</param>
    void AdjustCurrentHealth(float healthChange);

    /// <summary>
    /// The creature has no more health, i.e. they are dead.
    /// </summary>
    void HealthDepleted();
}
