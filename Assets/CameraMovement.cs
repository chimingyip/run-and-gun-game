using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float followSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + offset, followSpeed);
    }
}
