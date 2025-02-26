using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(Reseter), typeof(AnimatorController))]
public class Character : MonoBehaviour
{

    private Vector2 _startPoint;
    private CharacterMovement _characterMovement;
    private Reseter _reseter;
    private AnimatorController _animatorController;

    private void Awake()
    {
        _startPoint = transform.position;
        _characterMovement = GetComponent<CharacterMovement>();
        _reseter = GetComponent<Reseter>();
        _animatorController = GetComponent<AnimatorController>();
    }

    private void FixedUpdate()
    {
        _characterMovement.Move();

        _animatorController.SetXDirectionValue(_characterMovement.XMovementDirection);
    }

    public void ResetPosition()
    {
        _reseter.PositionReset(_startPoint);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Coin coin))
        {
            coin.CallRespawn();
        }
    }
}
