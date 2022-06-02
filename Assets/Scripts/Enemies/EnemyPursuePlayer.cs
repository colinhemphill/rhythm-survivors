using UnityEngine;

public class EnemyPursuePlayer : MonoBehaviour
{
    public float speed = 4.0f;

    private Transform target;
    private Rigidbody rb;
    private Vector3 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        float distance = speed * Time.deltaTime;
        Vector3 start = transform.position;
        Vector3 end = target.position;
        movement = Vector3.MoveTowards(start, end, distance);
        PursuePlayer();
    }

    private void PursuePlayer()
    {
        rb.MovePosition(movement);
        transform.LookAt(target);
    }
}
