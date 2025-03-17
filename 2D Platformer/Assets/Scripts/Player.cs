using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(Health))]
public class Player : Character
{
    private PlayerMovement _characterMovement;
    private AnimatorValueChanger _animatorController;

    private void Start()
    {
        _characterMovement = GetComponent<PlayerMovement>();
        _animatorController = GetComponentInChildren<AnimatorValueChanger>();
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

    public override void TakeDamage(float damage)
    {
        Health.TakeDamage(damage);
    }

    private void UseFirstAid(int healAmount)
    {
        Health.Heal(healAmount);
    }
}