using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorValueChanger : MonoBehaviour
{
    private readonly int XDirection = Animator.StringToHash(nameof(XDirection));
    private readonly int Attack = Animator.StringToHash(nameof(Attack));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetXDirectionValue(float value)
    {
        _animator.SetFloat(XDirection, value);
    }

    public void SetAttackTrigger()
    {
        _animator.SetTrigger(Attack);
    }
}
