using System.Collections;
using UnityEngine;

public class EnemyAttackPlayer : MonoBehaviour
{
    public float dps = 1.0f;
    private IEnumerator takingDamageCoroutine;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            takingDamageCoroutine = ApplyDamage(playerHealth);
            StartCoroutine(takingDamageCoroutine);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StopCoroutine(takingDamageCoroutine);
        }
    }

    IEnumerator ApplyDamage(PlayerHealth playerHealth)
    {
        while (true)
        {
            playerHealth.AdjustCurrentHealth(dps * -1);
            yield return new WaitForSeconds(1.0f);
        }
    }
}
