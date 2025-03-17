using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimator : MonoBehaviour
{
    private readonly int XDirection = Animator.StringToHash(nameof(XDirection));
    private readonly int Attack = Animator.StringToHash(nameof(Attack));

    private Animator _animator;

    public void PlayMove(float value)
    {
        _animator.SetFloat(XDirection, value);
    }

    public void PlayAttack()
    {
        _animator.SetTrigger(Attack);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}