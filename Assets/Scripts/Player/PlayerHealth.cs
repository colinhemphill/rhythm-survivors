using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [field: SerializeField]
    public float maxHealth { get; set; }
    public float currentHealth { get; set; }
    public bool isHealthDepleted { get; set; }

    public TextFadeInOut gameOverText;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
        animator.updateMode = AnimatorUpdateMode.UnscaledTime;
        animator.SetBool("Death_b", true);
        animator.SetInteger("DeathType_int", 2);
        StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        gameOverText.FadeIn();
        yield return new WaitForSeconds(gameOverText.fadeInTime + 1.0f);
        Time.timeScale = 0;
    }
}
