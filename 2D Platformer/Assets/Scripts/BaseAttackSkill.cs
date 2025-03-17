using UnityEngine;

public class BaseAttackSkill : Skill
{
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRadius;

    private AnimatorValueChanger _animatorValueChanger;

    private void Start()
    {
        _animatorValueChanger = GetComponentInChildren<AnimatorValueChanger>();
    }

    public override void Use()
    {
        if (IsReadyToUse)
        {
            _animatorValueChanger.SetAttackTrigger();

            Collider2D target = Physics2D.OverlapCircle(_attackPoint.position, _attackRadius, TargetLayer);

            if (target != null && target.TryGetComponent(out IDamageable obj))
                obj.TakeDamage(Damage);

            SetNotReadyToUse();

            Reloader.Reload(ReloadTime);
        }
    }
}