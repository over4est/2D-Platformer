using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Reseter : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void PositionReset(Vector2 point)
    {
        _rigidbody.velocity = Vector2.zero;

        transform.position = point;
    }
}
