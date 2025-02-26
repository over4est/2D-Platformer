using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private readonly int XDirection = Animator.StringToHash(nameof(XDirection));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetXDirectionValue(float value)
    {
        _animator.SetFloat(XDirection, value);
    }
}
