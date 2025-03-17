using System;
using System.Collections;
using UnityEngine;

public class VampirismCircle : MonoBehaviour
{
    [SerializeField] private float _lifetime;
    [SerializeField] private float _attackDelay;

    private Enemy _currentTarget;
    private float _damage;
    private Health _health;
    private LayerMask _targetLayer;
    private float _radiusScale = 0.5f;
    private WaitForSeconds _lifeWait;
    private WaitForSeconds _attackWait;

    public event Action<VampirismCircle> DisableNeeded;

    public float Lifetime => _lifetime;

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    public void SetLayerMask(LayerMask targetLayer)
    {
        _targetLayer = targetLayer;
    }

    private void Awake()
    {
        _health = GetComponentInParent<Health>();
        _lifeWait = new WaitForSeconds(_lifetime);
        _attackWait = new WaitForSeconds(_attackDelay);
    }

    private void OnEnable()
    {
        StartCoroutine(LifeCountdown(_lifetime));
        StartCoroutine(AttackCountdown(_attackDelay));
    }

    private void DrainLife(float damage, Enemy target)
    {
        if (target is IDamageable)
        {
            target.TakeDamage(damage);
            _health.Heal(damage);
        }
    }

    private Enemy GetTarget(Collider2D[] targets)
    {
        Enemy target = null;
        float distance = float.MaxValue;

        foreach (Collider2D tempTarget in targets)
        {
            if (tempTarget == null)
                continue;

            float tempDistance = (tempTarget.transform.position - transform.position).sqrMagnitude;

            if (distance > tempDistance && tempTarget.TryGetComponent(out Enemy enemy))
            {
                distance = tempDistance;
                target = enemy;
            }
        }

        return target;
    }

    private IEnumerator AttackCountdown(float delay)
    {
        int maxEnemiesCount = 5;
        Collider2D[] targets = new Collider2D[maxEnemiesCount];

        while (enabled)
        {
            yield return _attackWait;

            if (Physics2D.OverlapCircleNonAlloc(transform.position, transform.lossyScale.x * _radiusScale, targets, _targetLayer) > 0)
                _currentTarget = GetTarget(targets);

            if (_currentTarget != null)
                DrainLife(_damage, _currentTarget);
        }
    }

    private IEnumerator LifeCountdown(float delay)
    {
        yield return _lifeWait;

        DisableNeeded?.Invoke(this);
    }
}