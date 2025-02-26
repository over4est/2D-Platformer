using UnityEngine;

[RequireComponent(typeof(Mover), typeof(InputReader), typeof(GroundDetector))]
public class CharacterMovement : MonoBehaviour
{
    private Mover _mover;
    private InputReader _inputReader;
    private GroundDetector _groundDetector;

    public float XMovementDirection => _inputReader.XDirection;

    private void Awake()
    {
        _mover = GetComponent<Mover>();
        _inputReader = GetComponent<InputReader>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    public void Move()
    {
        if (_inputReader.XDirection != 0)
        {
            _mover.Move(XMovementDirection);
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
        }
    }
}