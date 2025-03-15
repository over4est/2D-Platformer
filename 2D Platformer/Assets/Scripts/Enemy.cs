using UnityEngine;

[RequireComponent(typeof(EnemyMovement), typeof(Attacker), typeof(CharacterDetector))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float _distanceToAttack;

    private Attacker _attacker;
    private Health _health;
    private EnemyMovement _enemyMovement;
    private AnimatorValueChanger _animatorValueChanger;
    private CharacterDetector _characterDetector;

    private void Awake()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _characterDetector = GetComponent<CharacterDetector>();
        _health = GetComponent<Health>();
        _attacker = GetComponent<Attacker>();
        _animatorValueChanger = GetComponentInChildren<AnimatorValueChanger>();
    }

    private void FixedUpdate()
    {
        if (_characterDetector.IsDetected == false)
        {
            _enemyMovement.MoveToWaypoint();
        }

        if (_characterDetector.IsDetected)
        {
            float sqrDistanceToTarget = (_characterDetector.DetectedCharacter.position - transform.position).sqrMagnitude;

            if (sqrDistanceToTarget <= _distanceToAttack && _attacker.IsReadyAttack)
            {
                _attacker.Attack();
            }

            _enemyMovement.MoveToCharacter(_characterDetector.DetectedCharacter);
        }

        _animatorValueChanger.SetXDirectionValue(_enemyMovement.XMovementDirection);
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}