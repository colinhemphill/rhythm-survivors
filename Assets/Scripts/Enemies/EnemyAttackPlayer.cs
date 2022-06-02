using UnityEngine;

public class EnemyAttackPlayer : MonoBehaviour
{
    private GameObject player;
    private BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Debug.Log("Collide with player");
            player = other.gameObject;
        }
    }
}
