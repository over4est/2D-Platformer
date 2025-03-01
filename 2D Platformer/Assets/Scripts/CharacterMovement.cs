using UnityEngine;

[RequireComponent(typeof(Mover), typeof(InputReader), typeof(GroundDetector))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private SpriteFlipper _spriteFlipper;

    private Mover _mover;
    private InputReader _inputReader;
    private GroundDetector _groundDetector;

    public float XMovementDirection => _inputReader.XDirection;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _groundDetector = GetComponent<GroundDetector>();
        _mover = GetComponent<Mover>();
    }

    public void Move()
    {
        if (_inputReader.XDirection != 0)
        {
            _spriteFlipper.TryFlip(XMovementDirection);
            _mover.Move(XMovementDirection);
        }

        if (_inputReader.GetIsJump() && _groundDetector.IsGround)
        {
            _mover.Jump();
        }
    }

    public void Attack(int damage)
    {
        if (_inputReader.GetIsAttack() && _attacker.IsReadyAttack)
        {
            _attacker.Attack(damage);
        }
    }
}