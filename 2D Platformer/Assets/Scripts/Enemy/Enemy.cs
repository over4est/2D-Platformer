using UnityEngine;

[RequireComponent(typeof(EnemyMovement), typeof(BaseAttackSkill), typeof(PlayerDetector))]
[RequireComponent(typeof(Health))]
public class Enemy : Character
{
    [SerializeField] private float _distanceToAttack;

    private BaseAttackSkill _baseAttack;
    private EnemyMovement _enemyMovement;
    private CharacterAnimator _animatorValueChanger;
    private PlayerDetector _playerDetector;

    public override void TakeDamage(float damage)
    {
        Health.TakeDamage(damage);
    }

    private void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _playerDetector = GetComponent<PlayerDetector>();
        _baseAttack = GetComponent<BaseAttackSkill>();
        _animatorValueChanger = GetComponentInChildren<CharacterAnimator>();
    }

    private void FixedUpdate()
    {
        if (_playerDetector.IsDetected == false)
        {
            _enemyMovement.MoveToWaypoint();
        }

        if (_playerDetector.IsDetected)
        {
            float sqrDistanceToTarget = (_playerDetector.DetectedCharacter.position - transform.position).sqrMagnitude;

            if (sqrDistanceToTarget <= _distanceToAttack)
            {
                _baseAttack.Use();
            }

            _enemyMovement.MoveToCharacter(_playerDetector.DetectedCharacter);
        }

        _animatorValueChanger.PlayMove(_enemyMovement.XMovementDirection);
    }
}