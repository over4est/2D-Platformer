using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(AnimatorValueChanger))]
public class Character : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _attackDamage;

    private int _currentHealth;
    private CharacterMovement _characterMovement;
    private AnimatorValueChanger _animatorController;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _characterMovement = GetComponent<CharacterMovement>();
        _animatorController = GetComponent<AnimatorValueChanger>();
    }

    private void FixedUpdate()
    {
        _characterMovement.Move();
        _characterMovement.Attack(_attackDamage);
        _animatorController.SetXDirectionValue(Mathf.Abs(_characterMovement.XMovementDirection));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out FirstAid firstAid))
        {
            UseFirstAid(firstAid.HealAmount);
            firstAid.CallRespawn();
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void UseFirstAid(int healAmount)
    {
        _currentHealth += healAmount;

        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }
}