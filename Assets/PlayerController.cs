using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 1f;
    [SerializeField]
    private Camera camera;
    private Rigidbody2D rb;

    private Vector2 moveInput;
    private Vector2 lookInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.deltaTime);

        Vector2 facingDirection = lookInput - rb.position;
        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnLook(InputValue value)
    {
        lookInput = camera.ScreenToWorldPoint(value.Get<Vector2>());
    }
}
