using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorValueChanger : MonoBehaviour
{
    private const string XDirection = nameof(XDirection);
    private const string Attack = nameof(Attack);

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