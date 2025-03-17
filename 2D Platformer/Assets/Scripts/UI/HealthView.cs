using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class HealthView : MonoBehaviour
{
    private Health _health;

    protected float MaxValue;

    private void Awake()
    {
        _health = GetComponent<Health>();
        MaxValue = _health.MaxValue;
    }

    private void OnEnable()
    {
        _health.ValueChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= ChangeValue;
    }

    protected abstract void ChangeValue(float value);
}