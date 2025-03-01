using UnityEngine;

[RequireComponent(typeof(CharacterMovement), typeof(AnimatorValueChanger), typeof(Health))]
public class Character : MonoBehaviour, IDamageable
{
    private CharacterMovement _characterMovement;
    private AnimatorValueChanger _animatorController;
    private Health _health;

    private void Awake()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        _animatorController = GetComponent<AnimatorValueChanger>();
        _health = GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        _characterMovement.Move();
        _animatorController.SetXDirectionValue(Mathf.Abs(_characterMovement.XMovementDirection));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out FirstAid firstAid))
        {
            UseFirstAid(firstAid.HealAmount);
            firstAid.Disable();
        }
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void UseFirstAid(int healAmount)
    {
        _health.Restore(healAmount);
    }
}