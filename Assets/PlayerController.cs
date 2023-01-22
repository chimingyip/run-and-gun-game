using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 1f;
    public float rotationOffset;
    [SerializeField]
    private Camera camera;
    private Rigidbody2D rb;

    private Vector2 moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.deltaTime);

        Vector3 mousePos = Input.mousePosition;
        Vector3 characterPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.z = 0;
        mousePos.x = mousePos.x - characterPos.x;
        mousePos.y = mousePos.y - characterPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
