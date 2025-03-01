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

    private void OnEnable()
    {
        _inputReader.JumpPressed += Jump;
        _inputReader.AttackPressed += Attack;
    }

    private void OnDisable()
    {
        _inputReader.JumpPressed -= Jump;
        _inputReader.AttackPressed -= Attack;
    }

    public void Move()
    {
        if (_inputReader.XDirection != 0)
        {
            _spriteFlipper.TryFlip(XMovementDirection);
            _mover.Move(XMovementDirection);
        }
    }

    private void Attack()
    {
        if (_attacker.IsReadyAttack)
        {
            _attacker.Attack();
        }
    }

    private void Jump()
    {
        if (_groundDetector.IsGround())
        {
            _mover.Jump();
        }
    }
}