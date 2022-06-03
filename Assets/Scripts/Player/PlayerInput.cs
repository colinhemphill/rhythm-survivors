using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float topSpeed = 10.0f;
    public float rotateSpeed = 20.0f;

    private Animator animator;
    private PlayerHealth playerHealth;
    private float movementX;
    private float movementY;
    private float heading;
    private float currentSpeed = 0.0f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
        animator.SetBool("Static_b", false);
    }

    private void Update()
    {
        if (playerHealth.isHealthDepleted)
        {
            return;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, heading - 90, 0)), Time.deltaTime * rotateSpeed);
        transform.Translate(Vector3.forward * movementY * topSpeed * Time.deltaTime, Space.World);
        transform.Translate(Vector3.right * movementX * topSpeed * Time.deltaTime, Space.World);
    }

    private void OnDeviceLost()
    {

    }

    private void OnDeviceRegained()
    {

    }

    private void OnControlsChanged()
    {

    }

    private void OnMove(InputValue movementValue)
    {
        if (playerHealth.isHealthDepleted)
        {
            return;
        }
        Vector2 movementVector = movementValue.Get<Vector2>();
        currentSpeed = movementVector.sqrMagnitude;

        SetMovementValues(movementVector);
        AnimateMove();
    }

    private void SetMovementValues(Vector2 movementVector)
    {
        movementX = movementVector.x;
        movementY = movementVector.y;

        if (Mathf.Abs(movementX) > 0 || Mathf.Abs(movementY) > 0)
        {
            heading = Mathf.Atan2(movementVector.y, -movementVector.x) * Mathf.Rad2Deg;
        }
    }

    private void AnimateMove()
    {
        float speedF = currentSpeed > 0 ? Mathf.Clamp(currentSpeed, 0.251f, 1) : 0;
        animator.SetFloat("Speed_f", speedF);
    }
}