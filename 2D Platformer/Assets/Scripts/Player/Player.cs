using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(Health), typeof(PlayerCombat))]
public class Player : Character
{
    private PlayerMovement _characterMovement;
    private CharacterAnimator _animatorController;

    public override void TakeDamage(float damage)
    {
        Health.TakeDamage(damage);
    }

    private void Start()
    {
        _characterMovement = GetComponent<PlayerMovement>();
        _animatorController = GetComponentInChildren<CharacterAnimator>();
    }

    private void FixedUpdate()
    {
        _characterMovement.Move();
        _animatorController.PlayMove(Mathf.Abs(_characterMovement.XMovementDirection));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out FirstAid firstAid))
        {
            UseFirstAid(firstAid.HealAmount);
            firstAid.Disable();
        }
    }

    private void UseFirstAid(int healAmount)
    {
        Health.Heal(healAmount);
    }
}