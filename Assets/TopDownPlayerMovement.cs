using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownPlayerMovement : MonoBehaviour
{
    // Components
    public Rigidbody2D rb;

    // Player properties
    [SerializeField]
    public float walkSpeed = 4f;
    private float speedLimiter = 0.7f;
    private float inputHorizontal;
    private float inputVertical;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputHorizontal = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        
    }
}
