using System.Collections;
using UnityEngine;

public class AttackTornado : MonoBehaviour
{
    public PlayerAttackSettings settings;

    private PlayerHealth playerHealth;
    private TargetNearestEnemy targetNearestEnemy;
    private GameObject attack;
    private Vector3 targetEnemyPosition;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        targetNearestEnemy = GetComponent<TargetNearestEnemy>();
    }

    private void Start()
    {
        StartCoroutine(Attack());
    }

    private void LateUpdate()
    {
        if (attack != null && targetEnemyPosition != null)
        {
            Debug.DrawRay(attack.transform.position, targetEnemyPosition, Color.red);
            attack.transform.position = Vector3.MoveTowards(attack.transform.position, targetEnemyPosition * settings.targetDistance, settings.movementSpeed * Time.deltaTime);
        }
    }

    IEnumerator Attack()
    {
        while (!playerHealth.isHealthDepleted)
        {
            targetEnemyPosition = targetNearestEnemy.EvaluateNearestEnemy();
            attack = Instantiate(settings.effectPrefab, transform, false);
            attack.transform.parent = transform.parent;
            yield return new WaitForSeconds(settings.repeatDelay);
        }
    }
}
