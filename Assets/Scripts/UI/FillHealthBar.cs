using UnityEngine;
using UnityEngine.UI;

public class FillHealthBar : MonoBehaviour
{
    public Image fillImage;

    private PlayerHealth playerHealth;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void Update()
    {
        float fillValue = playerHealth.currentHealth / playerHealth.maxHealth;

        if (playerHealth.isHealthDepleted)
        {
            GameObject.Destroy(this.gameObject);
        }

        slider.value = fillValue;
    }
}
