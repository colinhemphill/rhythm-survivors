using UnityEngine;

public class EnemyPursuePlayer : MonoBehaviour
{
    public float minimumSpeed = 2.5f;
    public float speedVariance = 1.0f;
    public float minimumRotateSpeed = 5.0f;
    public float rotateSpeedVariance = 20.0f;

    private float speed;
    private float rotateSpeed;
    private Transform target;
    private Rigidbody rb;
    private Vector3 movement;

    private void Start()
    {
        float speedModifier = Random.Range(0, speedVariance);
        speed = minimumSpeed + speedModifier;

        float rotateSpeedModifier = Random.Range(0, rotateSpeedVariance);
        rotateSpeed = minimumRotateSpeed + rotateSpeedModifier;

        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
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
        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
}
