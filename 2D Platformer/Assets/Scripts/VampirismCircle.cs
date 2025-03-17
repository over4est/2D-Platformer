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

    private void Update()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, transform.lossyScale.x * _radiusScale, _targetLayer);

        if (targets.Length > 0)
            _currentTarget = GetTarget(targets);
        else
            _currentTarget = null;
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    public void SetLayerMask(LayerMask targetLayer)
    {
        _targetLayer = targetLayer;
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
            float tempDistance = (tempTarget.transform.position - transform.position).sqrMagnitude;

            if (distance > tempDistance)
            {
                distance = tempDistance;
                target = tempTarget.GetComponent<Enemy>();
            }
        }

        return target;
    }

    private IEnumerator AttackCountdown(float delay)
    {
        while (enabled)
        {
            yield return _attackWait;

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