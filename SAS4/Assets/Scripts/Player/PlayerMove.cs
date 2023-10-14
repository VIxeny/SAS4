using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private Vector2 _direction;
    [SerializeField] [Range(1, 10)] private float movingSpeed = 5f;

    private void OnValidate()
    {
        rb ??= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = _direction * movingSpeed;
    }

    public void GetMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }
}