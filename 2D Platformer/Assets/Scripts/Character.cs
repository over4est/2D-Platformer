using UnityEngine;

[RequireComponent(typeof(Health))]
public abstract class Character : MonoBehaviour, IDamageable
{
    private Health _health;

    protected Health Health => _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Died += Die;
    }

    private void OnDisable()
    {
        _health.Died -= Die;
    }

    public abstract void TakeDamage(float damage);

    protected void Die()
    {
        gameObject.SetActive(false);
    }
}