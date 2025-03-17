using UnityEngine;

[RequireComponent(typeof(Mover), typeof(InputReader), typeof(GroundDetector))]
public class PlayerMovement : MonoBehaviour
{
    private SpriteFlipper _spriteFlipper;
    private Mover _mover;
    private InputReader _inputReader;
    private GroundDetector _groundDetector;

    public float XMovementDirection => _inputReader.XDirection;

    public void Move()
    {
        if (_inputReader.XDirection != 0)
        {
            _spriteFlipper.HandleDirection(XMovementDirection);
            _mover.Move(XMovementDirection);
        }
    }

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _groundDetector = GetComponent<GroundDetector>();
        _mover = GetComponent<Mover>();
        _spriteFlipper = GetComponentInChildren<SpriteFlipper>();
    }

    private void OnEnable()
    {
        _inputReader.JumpPressed += Jump;
    }

    private void OnDisable()
    {
        _inputReader.JumpPressed -= Jump;
    }

    private void Jump()
    {
        if (_groundDetector.IsGround())
        {
            _mover.Jump();
        }
    }
}