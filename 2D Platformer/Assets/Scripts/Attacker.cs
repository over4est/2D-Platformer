using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _attackDamage;
    [SerializeField] private float _attackDelay;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _enemyMask;

    private AnimatorValueChanger _animatorValueChanger;
    private WaitForSeconds _wait;

    public bool IsReadyAttack { get; private set; } = true;

    private void Awake()
    {
        _animatorValueChanger = GetComponentInChildren<AnimatorValueChanger>();
        _wait = new WaitForSeconds(_attackDelay);
    }

    public void Attack()
    {
        _animatorValueChanger.SetAttackTrigger();

        Collider2D target = Physics2D.OverlapCircle(_attackPoint.position, _attackRadius, _enemyMask);

        if (target != null && target.TryGetComponent(out IDamageable obj))
        {
            obj.TakeDamage(_attackDamage);
        }

        IsReadyAttack = false;

        StartCoroutine(AttackReload(_wait));
    }

    private IEnumerator AttackReload(WaitForSeconds wait)
    {
        yield return wait;

        IsReadyAttack = true;
    }
}