using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
