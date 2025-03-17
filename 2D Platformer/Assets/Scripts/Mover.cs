using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;

    public void Move(float xDirection)
    {
        _rigidbody.velocity = new Vector2(xDirection * _movementSpeed, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0f);
        _rigidbody.AddForce(new Vector2(0f, _jumpForce));
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
}