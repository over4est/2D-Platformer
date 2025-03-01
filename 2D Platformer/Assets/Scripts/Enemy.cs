using UnityEngine;

[RequireComponent(typeof(EnemyMovement), typeof(AnimatorValueChanger), typeof(CharacterDetector))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Attacker _attacker;
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _distanceToAttack;
    [SerializeField] private int _damage;

    private int _currentHealth;
    private EnemyMovement _enemyMovement;
    private AnimatorValueChanger _animatorValueChanger;
    private CharacterDetector _characterDetector;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _enemyMovement = GetComponent<EnemyMovement>();
        _animatorValueChanger = GetComponent<AnimatorValueChanger>();
        _characterDetector = GetComponent<CharacterDetector>();
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
                _attacker.Attack(_damage);
            }

            _enemyMovement.MoveToCharacter(_characterDetector.DetectedCharacter);
        }

        _animatorValueChanger.SetXDirectionValue(_enemyMovement.XMovementDirection);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}