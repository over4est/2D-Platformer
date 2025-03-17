using UnityEngine;

[RequireComponent(typeof(Mover), typeof(InputReader), typeof(GroundDetector))]
[RequireComponent(typeof(BaseAttackSkill), typeof(VampirismSkill))]
public class PlayerMovement : MonoBehaviour
{
    private BaseAttackSkill _baseAttack;
    private SpriteFlipper _spriteFlipper;
    private Mover _mover;
    private InputReader _inputReader;
    private GroundDetector _groundDetector;
    private VampirismSkill _vampirismSkill;

    public float XMovementDirection => _inputReader.XDirection;

    private void Awake()
    {
        _vampirismSkill = GetComponent<VampirismSkill>();
        _baseAttack = GetComponent<BaseAttackSkill>();
        _inputReader = GetComponent<InputReader>();
        _groundDetector = GetComponent<GroundDetector>();
        _mover = GetComponent<Mover>();
        _spriteFlipper = GetComponentInChildren<SpriteFlipper>();
    }

    private void OnEnable()
    {
        _inputReader.JumpPressed += Jump;
        _inputReader.AttackPressed += UseAttack;
        _inputReader.VampireSkillPressed += UseVampoireSkill;
    }

    private void OnDisable()
    {
        _inputReader.JumpPressed -= Jump;
        _inputReader.AttackPressed -= UseAttack;
        _inputReader.VampireSkillPressed -= UseVampoireSkill;
    }

    public void Move()
    {
        if (_inputReader.XDirection != 0)
        {
            _spriteFlipper.TryFlip(XMovementDirection);
            _mover.Move(XMovementDirection);
        }
    }

    private void UseAttack()
    {
        _baseAttack.Use();
    }

    private void UseVampoireSkill()
    {
        _vampirismSkill.Use();
    }

    private void Jump()
    {
        if (_groundDetector.IsGround())
        {
            _mover.Jump();
        }
    }
}