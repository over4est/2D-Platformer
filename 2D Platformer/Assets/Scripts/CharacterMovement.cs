using UnityEngine;

[RequireComponent(typeof(Mover), typeof(InputReader), typeof(GroundDetector))]
[RequireComponent(typeof(Attacker))]
public class CharacterMovement : MonoBehaviour
{
    private Attacker _attacker;
    private SpriteFlipper _spriteFlipper;
    private Mover _mover;
    private InputReader _inputReader;
    private GroundDetector _groundDetector;

    public float XMovementDirection => _inputReader.XDirection;

    private void Awake()
    {
        _attacker = GetComponent<Attacker>();
        _inputReader = GetComponent<InputReader>();
        _groundDetector = GetComponent<GroundDetector>();
        _mover = GetComponent<Mover>();
        _spriteFlipper = GetComponentInChildren<SpriteFlipper>();
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