using UnityEngine;

public class TargetNearestEnemy : MonoBehaviour
{
    public Vector3 EvaluateNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Vector3 playerPosition = transform.position;
        Vector3 bestTarget = playerPosition;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            Vector3 enemyPosition = enemy.transform.position;
            Vector3 heading = enemyPosition - playerPosition;
            heading.y = 0;

            float magnitude = heading.sqrMagnitude;

            if (heading.sqrMagnitude < closestDistance)
            {
                closestDistance = magnitude;
                bestTarget = enemyPosition;
            }
        }

        return bestTarget;
    }
}
