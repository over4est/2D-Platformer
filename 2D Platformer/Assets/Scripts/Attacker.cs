using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AnimatorValueChanger))]
public class Attacker : MonoBehaviour
{
    [SerializeField] private float _attackDelay;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRadius;
    [SerializeField] private LayerMask _enemyMask;

    private AnimatorValueChanger _animatorValueChanger;

    public bool IsReadyAttack { get; private set; } = true;

    private void Awake()
    {
        _animatorValueChanger = GetComponent<AnimatorValueChanger>();
    }

    public void Attack(int damage)
    {
        _animatorValueChanger.SetAttackTrigger();

        Collider2D target = Physics2D.OverlapCircle(_attackPoint.position, _attackRadius, _enemyMask);

        if (target != null && target.TryGetComponent(out IDamageable obj))
        {
            obj.TakeDamage(damage);
        }

        IsReadyAttack = false;

        StartCoroutine(AttackReload(_attackDelay));
    }

    private IEnumerator AttackReload(float reloadTime)
    {
        var wait = new WaitForSeconds(reloadTime);

        yield return wait;

        IsReadyAttack = true;
    }
}